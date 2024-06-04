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
            /* you need to add an appsettings.json file with the following content:
           {
              "MKIOSubscriptionName": "yourMKIOsubscriptionname",
              "MKIOToken": "yourMKIOtoken",
              "TenantId" : "your Azure tenant ID " // optional
           }
          */

            Console.WriteLine("Sample that uploads a file in a new asset, does a video encoding to multiple bitrate with MK.IO and publish the output asset for clear streaming.");

            // Build a config object, using env vars and JSON providers.
            IConfigurationRoot config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            Console.WriteLine($"Using '{config["MKIOSubscriptionName"]}' MK.IO subscription.");

            // Creating a unique suffix so that we don't have name collisions if you run the sample
            // multiple times without cleaning up.
            string uniqueId = MKIOClient.GenerateUniqueName(string.Empty);
            string inputAssetName = $"input-{uniqueId}";
            string outputAssetName = $"output-{uniqueId}";
            string jobName = $"job-{uniqueId}";
            string locatorName = $"locator-{uniqueId}";

            // MK.IO Client creation
            var client = new MKIOClient(config["MKIOSubscriptionName"]!, config["MKIOToken"]!);

            // Create a new input Asset and upload the specified local video file into it.
            var inputAsset = await CreateInputAssetAsync(client, config["StorageName"], config["TenantId"], inputAssetName);

            // Output from the encoding Job must be written to an Asset, so let's create one
            var outputAsset = await CreateOutputAssetAsync(client, config["StorageName"], outputAssetName, $"encoded asset from {inputAsset.Name} using CVQ720pTransform transform");

            // Ensure that you have the desired encoding Transform. This is really a one time setup operation.
            TransformSchema transform = await CreateOrUpdateTransformAsync(client);

            var encodingJob = await SubmitJobAsync(client, jobName, transform, inputAsset, outputAsset);

            encodingJob = await WaitForJobToFinishAsync(client, transform.Name, encodingJob.Name);

            // Encoding is finished.

            if (encodingJob.Properties.State != JobState.Finished)
            {
                Console.WriteLine("Encoding job cancelled or in error.");
                return;
            }

            // Create a locator for clear streaming
            var locator = client.StreamingLocators.Create(
                 locatorName,
                 new StreamingLocatorProperties
                 {
                     AssetName = outputAsset.Name,
                     StreamingPolicyName = PredefinedStreamingPolicy.ClearStreamingOnly
                 });

            // list the streaming endpoint(s) and propose creation if needed
            await ListStreamingEndpointsAndCreateOneIfNeededAsync(client);

            // Display streaming paths and test player urls
            await ListStreamingUrlsAsync(client, locator.Name);

            Console.WriteLine("Press Enter to close the app.");
            Console.ReadLine();
        }

        private static async Task ListStreamingEndpointsAndCreateOneIfNeededAsync(MKIOClient client)
        {
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
                }
            }
        }

        private static async Task ListStreamingUrlsAsync(MKIOClient client, string locatorName)
        {
            // list Streaming Endpoints
            var streamingEndpoints = await client.StreamingEndpoints.ListAsync();

            // List the streaming Url
            var paths = await client.StreamingLocators.ListUrlPathsAsync(locatorName);
            Console.WriteLine($"Streaming paths for locator '{locatorName}':");
            foreach (var path in paths.StreamingPaths)
            {
                Console.WriteLine($"   Streaming protocol : {path.StreamingProtocol}");
                foreach (var p in path.Paths)
                {
                    foreach (var se in streamingEndpoints)
                    {
                        Console.WriteLine($"      Url : https://{se.Properties.HostName}{p}");
                        Console.WriteLine($"      Test player url: " + string.Format(BitmovinPlayer, path.StreamingProtocol.ToString().ToLower(), Uri.EscapeDataString("https://" + se.Properties.HostName + p)));
                    }
                }
                Console.WriteLine();
            }
        }

        private static async Task<AssetSchema> CreateOutputAssetAsync(MKIOClient client, string storageName, string assetName, string description)
        {
            // Create an empty output asset

            var outputAsset = await client.Assets.CreateOrUpdateAsync(
                assetName,
                null,
                storageName!,
                description,
                AssetContainerDeletionPolicyType.Retain, null,
                new Dictionary<string, string> { { "typeAsset", "encoded" } }
                );
            Console.WriteLine($"Output asset '{outputAsset.Name}' created.");

            return outputAsset;
        }

        private static async Task<JobSchema> WaitForJobToFinishAsync(MKIOClient client, string transformName, string jobName)
        {
            JobSchema job;

            do
            {
                job = await client.Jobs.GetAsync(transformName, jobName);
                Console.WriteLine(job.Properties.State + (job.Properties.Outputs.First().Progress != null ? $" {job.Properties.Outputs.First().Progress}%" : string.Empty));
                Thread.Sleep(10000);
            }
            while (job.Properties.State == JobState.Queued || job.Properties.State == JobState.Scheduled || job.Properties.State == JobState.Processing);

            return job;
        }

        private static async Task<AssetSchema> CreateInputAssetAsync(MKIOClient client, string storageName, string tenantId, string assetName)
        {
            // Create an input asset
            var inputAsset = await client.Assets.CreateOrUpdateAsync(
                assetName,
                null,
                storageName!,
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
                    TenantId = tenantId
                }
                )
                );

            // User or app must have Storage Blob Data Contributor on the account for the upload to work!
            // Upload a blob (e.g., from a local file)
            var blobName = InputMP4FileName; // Replace with your blob name
            var blobClient = blobContainerClient.GetBlobClient(blobName);
            await blobClient.UploadAsync(InputMP4FileName);
            Console.WriteLine($"File '{InputMP4FileName}' uploaded to input asset.");
            return inputAsset;
        }


        private static async Task<TransformSchema> CreateOrUpdateTransformAsync(MKIOClient client)
        {
            // Create or update a transform for CVQ encoding
            var transform = await client.Transforms.CreateOrUpdateAsync("CVQ720pTransform", new TransformProperties
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
            return transform;
        }

        private static async Task<JobSchema> SubmitJobAsync(MKIOClient client, string jobName, TransformSchema transform, AssetSchema inputAsset, AssetSchema outputAsset)
        {
            // Create the encoding job
            var encodingJob = await client.Jobs.CreateAsync(
                transform.Name,
                jobName,
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
            return encodingJob;
        }
    }
}
