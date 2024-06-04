// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Azure.Identity;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using MK.IO;
using MK.IO.Models;

namespace Sample
{
    public class ProgramDemo
    {
        private const string InputMP4FileName = @"Ignite.mp4";
        private const string BitmovinPlayer = "https://bitmovin.com/demos/stream-test?format={0}&manifest={1}";

        public static async Task SimpleEncodingAndPublishing()
        {
            Console.WriteLine("Sample that uploads a file in a new asset, does a video encoding to multiple bitrate with MK.IO and publish the output asset for clear streaming.");

            /* you need to add an appsettings.json file with the following content:
             {
                "MKIOSubscriptionName": "yourMKIOsubscriptionname",
                "MKIOToken": "yourMKIOtoken",
                "TenantId" : "your Azure tenant ID " // optional
             }
            */

            // Build a config object, using env vars and JSON providers.
            IConfigurationRoot config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            Console.WriteLine($"Using '{config["MKIOSubscriptionName"]}' MK.IO subscription.");

            // **********************
            // MK.IO Client creation
            // **********************

            var client = new MKIOClient(config["MKIOSubscriptionName"]!, config["MKIOToken"]!);

            // Create an input asset
            var inputAsset = await client.Assets.CreateOrUpdateAsync(
                MKIOClient.GenerateUniqueName("asset"),
                null,
                config["StorageName"]!,
                $"input asset {InputMP4FileName}",
                AssetContainerDeletionPolicyType.Retain,
                null,
                new Dictionary<string, string> { { "typeAsset", "source" } }
            );
            Console.WriteLine($"Input asset '{inputAsset.Name}' created.");

            // Create an interactive browser credential which will use the system authentication broker
            var blobContainerClient = new BlobContainerClient(
                new Uri($"https://{inputAsset.Properties.StorageAccountName}.blob.core.windows.net/{inputAsset.Properties.Container}"),
                new InteractiveBrowserCredential(new InteractiveBrowserCredentialOptions()
                {
                    TenantId = config["TenantId"]
                }
                )
                );

            // User or app must have Storage Blob Data Contributor on the account for the upload to work!
            // Upload a blob (e.g., from a local file)
            var blobName = InputMP4FileName; // Replace with your blob name
            var blobClient = blobContainerClient.GetBlobClient(blobName);
            await blobClient.UploadAsync(InputMP4FileName);
            Console.WriteLine($"File '{InputMP4FileName}' uploaded to input asset.");

            // Create an empty output asset
            var jobId = MKIOClient.GenerateUniqueName(string.Empty);
            var outputAsset = client.Assets.CreateOrUpdate(
                $"{inputAsset.Name}-encoded-{jobId}",
                null,
                config["StorageName"]!,
                $"encoded asset from {inputAsset.Name} with job {jobId} using CVQ720pTransform transform",
                AssetContainerDeletionPolicyType.Retain, null,
                new Dictionary<string, string> { { "typeAsset", "encoded" } }
                );
            Console.WriteLine($"Output asset '{outputAsset.Name}' created.");

            // Create or update a transform for CVQ encoding
            var transform = client.Transforms.CreateOrUpdate("CVQ720pTransform", new TransformProperties
            {
                Description = "Encoding with CVQ 720p",
                Outputs = new List<TransformOutput>
                {
                    new() {
                        Preset = new BuiltInStandardEncoderPreset(EncoderNamedPreset.H264MultipleBitrate720pWithCVQ),
                        RelativePriority = TransformOutputPriorityType.Normal
                    }
                }
            });
            Console.WriteLine($"Transform '{transform.Name}' created/updated.");

            // Create the encoding job
            var encodingJob = client.Jobs.Create(
                transform.Name,
                $"job-{jobId}",
                new JobProperties
                {
                    Description = $"My job which encodes '{inputAsset.Name}' to '{outputAsset.Name}' with '{transform.Name}' transform.",
                    Priority = JobPriorityType.Normal,
                    Input = new JobInputAsset(
                       inputAsset.Name,
                       [
                           InputMP4FileName
                       ]),
                    Outputs =
                    [
                       new JobOutputAsset()
                       {
                           AssetName= outputAsset.Name
                       }
                    ]
                }
                );
            Console.WriteLine($"Encoding job '{encodingJob.Name}' submitted.");

            while (encodingJob.Properties.State == JobState.Queued || encodingJob.Properties.State == JobState.Scheduled || encodingJob.Properties.State == JobState.Processing)
            {
                encodingJob = client.Jobs.Get(transform.Name, encodingJob.Name);
                Console.WriteLine(encodingJob.Properties.State + (encodingJob.Properties.Outputs.First().Progress != null ? $" {encodingJob.Properties.Outputs.First().Progress}%" : string.Empty));
                Thread.Sleep(10000);
            }

            // Encoding is finished.
            // Create a locator for clear streaming
            var locator = client.StreamingLocators.Create(
                 MKIOClient.GenerateUniqueName("locator"),
                 new StreamingLocatorProperties
                 {
                     AssetName = "asset-0ee54a50-encoded-ad92f7d6",//outputAsset.Name,
                     StreamingPolicyName = PredefinedStreamingPolicy.ClearStreamingOnly
                 });

            // list the streaming endpint(s) and propose creation if none
            var streamingEndpoints = await client.StreamingEndpoints.ListAsync();
            if (streamingEndpoints.Any())
            {
                Console.WriteLine("Streaming endpoints:");
                foreach (var streamingEndpoint in streamingEndpoints)
                {
                    Console.WriteLine($"   {streamingEndpoint.Name} ({streamingEndpoint.Properties.ResourceState})");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No streaming endpoint found. Do you want to create one and start it? (Y/N)");
                var response = Console.ReadLine();
                if (response == "Y" || response == "y")
                {
                    var sub = await client.Account.GetSubscriptionAsync();
                    var locs = await client.Account.ListAllLocationsAsync();
                    var locationToUse = locs.FirstOrDefault(l => l.Metadata.Id == sub.Spec.LocationId);

                    var streamingEndpoint = await client.StreamingEndpoints.CreateAsync(
                        MKIOClient.GenerateUniqueName("endpoint"),
                        locationToUse.Metadata.Name,
                        new StreamingEndpointProperties
                        {
                            Description = "Streaming endpoint created by sample"
                        },
                        true
                        );
                    Console.WriteLine($"Streaming endpoint '{streamingEndpoint.Name}' created and starting.");
                    Console.WriteLine();
                    streamingEndpoints = await client.StreamingEndpoints.ListAsync();
                }
            }

            // List the streaming Url
            var paths = client.StreamingLocators.ListUrlPaths(locator.Name);
            Console.WriteLine($"Streaming paths for locator '{locator.Name}':");
            foreach (var path in paths.StreamingPaths)
            {
                Console.WriteLine($"   Streaming protocol : {path.StreamingProtocol}");
                foreach (var p in path.Paths)
                {
                    foreach (var se in streamingEndpoints)
                    {
                        Console.WriteLine($"      https://{se.Properties.HostName}{p}");
                    }
                }
            }
            Console.WriteLine();

            Console.WriteLine($"BITMOVIN test player URLs:");
            foreach (var path in paths.StreamingPaths)
            {
                Console.WriteLine($"   Streaming protocol : {path.StreamingProtocol}");
                foreach (var p in path.Paths)
                {
                    foreach (var se in streamingEndpoints)
                    {
                        Console.WriteLine($"      " + string.Format(BitmovinPlayer, path.StreamingProtocol.ToString().ToLower(), Uri.EscapeDataString("https://" + se.Properties.HostName + p)));
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine("Press Enter to close the app.");
            Console.ReadLine();
        }
    }
}
