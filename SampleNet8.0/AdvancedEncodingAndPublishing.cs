// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Azure.Identity;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using MK.IO;
using MK.IO.Models;

namespace Sample
{
    /// <summary>
    /// Sample code for MK.IO using MK.IO .NET SDK that does the following:
    /// - upload a mp4 file to a new asset using authentication in the browser (you need contribution role on the storage)
    /// - create the output encoded asset
    /// - create/update a encoding transform
    /// - submit an encoding job
    /// - create/update a transform to do the transcription of the video
    /// - submit a job to generate the transcription (vtt)
    /// - create/update a transform to insert the vtt as a text track
    /// - submit a job to insert the vtt as a text track in the encoded asset
    /// - create/update a transform for thumbnails
    /// - submit a job to generate a thumbnails sprite
    /// - create a download locator for the thumbnails sprite and thumbnails vtt and list the Urls
    /// - create a streaming locator for the encoded asset
    /// - create and start a streaming endpoint if there is none
    /// - list the streaming urls and test player urls.
    /// - clean the created resources if the user accepts
    /// </summary>
    public class AdvancedEncodingAndPublishing
    {
        private const string _encodingTransformName = "H264MultipleBitrate720pTransform";
        private const EncoderNamedPreset _encodingPreset = EncoderNamedPreset.H264MultipleBitrate720p;
        private const string _thumbnailTransformName = "ThumbnailTransform";
        private const string _vodTranscriptionTransformName = "VODTranscriptionTransform";
        private const string _textTrackInsertionTransformName = "TextTrackInserterTransform";
        private const string _inputMP4FileName = @"Ignite.mp4";
        private const string _bitmovinPlayer = "https://bitmovin.com/demos/stream-test?format={0}&manifest={1}";

        public static async Task RunAsync()
        {
            /* you need to add an appsettings.json file with the following content:
           {
              "MKIOSubscriptionName": "yourMKIOsubscriptionname",
              "MKIOToken": "yourMKIOPersonalAPIToken",
              "StorageName": "yourStorageAccountName",
              "TenantId" : "your Azure tenant ID " // optional
           }
          */

            Console.WriteLine("Sample for MK.IO that uploads a file in a new asset, does a video encoding to multiple bitrate, generates and inserts a VTT as text track, generates a thumbnails sprite and publishes the output asset for clear streaming.");
            Console.WriteLine();

            // Load settings from the appsettings.json file and check them
            IConfigurationRoot config = LoadAndCheckSettings();

            // Creating a unique suffix so that we don't have name collisions if you run the sample
            // multiple times without cleaning up.
            string uniqueId = MKIOClient.GenerateUniqueName(string.Empty);
            string inputAssetName = $"input-{uniqueId}";
            string outputEncodedAssetName = $"output-{uniqueId}-encoded";
            string encodingJobName = $"job-{uniqueId}-encoding";
            string locatorName = $"locator-{uniqueId}";

            string outputThumbnailAssetName = $"{outputEncodedAssetName}-thumbnail";
            string thumbnailJobName = $"job-{uniqueId}-thumbnail";
            string locatorThumbnailName = $"{locatorName}-thumbnail";

            string outputVTTAssetName = $"{inputAssetName}-transcription";
            string vodTranscriptionJobName = $"job-{uniqueId}-vodtranscription";
            string textTrackInsertionJobName = $"job-{uniqueId}-texttrackinsertion";

            // MK.IO Client creation
            var client = new MKIOClient(config["MKIOSubscriptionName"]!, config["MKIOToken"]!);

            // Main video encoding ------------------------------------------------------------------------------------------------------------------------------------------

            // Create a new input Asset and upload the specified local video file into it. We use the delete flag to delete the blob and container if we delete the asset in MK.IO
            _ = await CreateInputAssetAndUploadFileAsync(client, config["StorageName"]!, config["TenantId"]!, inputAssetName, _inputMP4FileName);

            // Output from the encoding Job must be written to an Asset, so let's create one. We use the delete flag to delete the blob and container if we delete the asset in MK.IO
            _ = await CreateOutputAssetAsync(client, config["StorageName"]!, outputEncodedAssetName, $"encoded asset from {inputAssetName} using {_encodingTransformName} transform");

            // Ensure that you have the desired encoding Transform. This is really a one time setup operation.
            _ = await CreateOrUpdateTransformAsync(client, _encodingTransformName, _encodingPreset);

            // Submit a job request to MK.IO to apply the specified Transform to a given input video.
            _ = await SubmitJobAsync(client, _encodingTransformName, encodingJobName, inputAssetName, outputEncodedAssetName, _inputMP4FileName);

            // Polls the status of the job and wait for it to finish.
            var job = await WaitForJobToFinishAsync(client, _encodingTransformName, encodingJobName);

            if (job.Properties.State != JobState.Finished)
            {
                // Alert the user if issue with the encoding job
                DisplayJobStatusWhenCompleted(job);
                await CleanIfUserAcceptsAsync(client, [inputAssetName, outputEncodedAssetName], [(_encodingTransformName, encodingJobName)]);
            }
            else
            {
                // VOD AI based transcription -------------------------------------------------------------------------------------------------------------------------------
                // See https://docs.mk.io/docs/vod-transcription

                // Create a transform for the VOD Transcription
                _ = await CreateOrUpdateTransformVodTranscriptAsync(client, _vodTranscriptionTransformName);

                // Create a new asset to store the generated VTT file (transcript)
                _ = await CreateOutputAssetAsync(client, config["StorageName"]!, outputVTTAssetName);

                // Submit a job request to MK.IO to apply the specified Transform to a given input video.
                _ = await SubmitJobAsync(client, _vodTranscriptionTransformName, vodTranscriptionJobName, inputAssetName, outputVTTAssetName, _inputMP4FileName);

                // Polls the status of the job and wait for it to finish.
                _ = await WaitForJobToFinishAsync(client, _vodTranscriptionTransformName, vodTranscriptionJobName);


                // WebVTT file inserted as text track -----------------------------------------------------------------------------------------------------------------------
                // See https://docs.mk.io/docs/webvtt-subtitle-side-loading

                // Create the transform to insert the VTT file as a text track
                _ = await CreateOrUpdateTransformTextTrackAsync(client, _textTrackInsertionTransformName);

                // Submit a job request to MK.IO to apply the specified Transform to a given input video.
                _ = await SubmitJobAsync(client, _textTrackInsertionTransformName, textTrackInsertionJobName, outputVTTAssetName, outputEncodedAssetName, Path.GetFileNameWithoutExtension(_inputMP4FileName) + ".vtt");

                // Polls the status of the job and wait for it to finish.
                _ = await WaitForJobToFinishAsync(client, _textTrackInsertionTransformName, textTrackInsertionJobName);


                // Thumbnails sprite generation -----------------------------------------------------------------------------------------------------------------------------
                // See https://docs.mk.io/docs/thumbnails-generation

                // Output asset to host the thumbnail.
                _ = await CreateOutputAssetAsync(client, config["StorageName"]!, outputThumbnailAssetName, $"Thumbnail asset from {outputEncodedAssetName} using {_thumbnailTransformName} transform");

                // Ensure that you have the desired encoding Transform. This is really a one time setup operation.
                _ = await CreateOrUpdateThumbnailTransformAsync(client, _thumbnailTransformName);

                // Submit a job request to MK.IO to apply the specified Transform to a given input video.
                _ = await SubmitJobAsync(client, _thumbnailTransformName, thumbnailJobName, outputEncodedAssetName, outputThumbnailAssetName, Path.GetFileNameWithoutExtension(_inputMP4FileName) + ".ism");

                // Polls the status of the job and wait for it to finish.
                var thumbnailJob = await WaitForJobToFinishAsync(client, _thumbnailTransformName, thumbnailJobName);

                if (thumbnailJob.Properties.State == JobState.Finished)
                {
                    // Create a locator for clear streaming
                    _ = await CreateDownloadLocatorAsync(client, outputThumbnailAssetName, locatorThumbnailName);

                    // Display download paths
                    await ListDownloadUrlsAsync(client, locatorThumbnailName);
                }


                // Publishing video asset -----------------------------------------------------------------------------------------------------------------------------------

                // Create a locator for clear streaming
                _ = await CreateStreamingLocatorAsync(client, outputEncodedAssetName, locatorName);

                // List the streaming endpoint(s) and propose creation if needed
                var createdEndpoint = await ListStreamingEndpointsAndCreateOneIfNeededAsync(client);

                // Display streaming paths and test player urls
                await ListStreamingUrlsAsync(client, locatorName);

                // Cleanign assets-------------------------------------------------------------------------------------------------------------------------------------------

                await CleanIfUserAcceptsAsync(client,
                    [inputAssetName, outputEncodedAssetName, outputVTTAssetName, outputThumbnailAssetName],
                    [(_encodingTransformName, encodingJobName), (_vodTranscriptionTransformName, vodTranscriptionJobName), (_textTrackInsertionTransformName, textTrackInsertionJobName), (_thumbnailTransformName, thumbnailJobName)],
                    createdEndpoint);
            }
        }

        /// <summary>
        /// Does the settings loading and checking.
        /// </summary>
        /// <returns>Configuration.</returns>
        /// <exception cref="Exception"></exception>
        private static IConfigurationRoot LoadAndCheckSettings()
        {
            // Build a config object, using env vars and JSON providers.
            IConfigurationRoot config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            // Checking settings
            if (string.IsNullOrEmpty(config["MKIOSubscriptionName"]) || string.IsNullOrEmpty(config["MKIOToken"]) || string.IsNullOrEmpty(config["StorageName"]))
            {
                Console.WriteLine("Missing MKIOSubscriptionName, MKIOToken, or StorageName in configuration file.");
                throw new Exception("Missing mandatory configuration settings.");
            }

            Console.WriteLine($"Using '{config["MKIOSubscriptionName"]!}' MK.IO subscription.");
            return config;
        }

        /// <summary>
        /// Creates a new input Asset and uploads the specified local video file into it.
        /// </summary>
        /// <param name="client">The MK.IO client.</param>
        /// <param name="storageName">The storage name.</param>
        /// <param name="tenantId">The Azure Tenant Id</param>
        /// <param name="assetName">The asset name.</param>
        /// <param name="fileToUpload">The file you want to upload into the asset.</param>
        /// <returns>The asset.</returns>
        private static async Task<AssetSchema> CreateInputAssetAsync(MKIOClient client, string storageName, string tenantId, string assetName, string? description = null)
        {
            // Create an input asset
            var inputAsset = await client.Assets.CreateOrUpdateAsync(
                assetName,
                null,
                storageName!,
                description,
                AssetContainerDeletionPolicyType.Delete,
                null,
                new Dictionary<string, string> { { "typeAsset", "source" } }
            );
            Console.WriteLine($"Input asset '{inputAsset.Name}' created.");

            return inputAsset;
        }

        /// <summary>
        /// Creates a new input Asset and uploads the specified local video file into it.
        /// </summary>
        /// <param name="client">The MK.IO client.</param>
        /// <param name="storageName">The storage name.</param>
        /// <param name="tenantId">The Azure Tenant Id</param>
        /// <param name="assetName">The asset name.</param>
        /// <param name="fileToUpload">The file you want to upload into the asset.</param>
        /// <returns>The asset.</returns>
        private static async Task<AssetSchema> CreateInputAssetAndUploadFileAsync(MKIOClient client, string storageName, string tenantId, string assetName, string fileToUpload)
        {

            var inputAsset = await CreateInputAssetAsync(client, storageName, tenantId, assetName, $"input asset {fileToUpload}");

            // We wait 2 seconds to let time to MK.IO create the container
            await Task.Delay(2000);

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
            var blobClient = blobContainerClient.GetBlobClient(Path.GetFileName(fileToUpload));
            await blobClient.UploadAsync(fileToUpload);
            Console.WriteLine($"File '{fileToUpload}' uploaded to input asset.");
            return inputAsset;
        }

        /// <summary>
        /// Creates an ouput asset. The output from the encoding Job must be written to an Asset.
        /// </summary>
        /// <param name="client">The MK.IO client.</param>
        /// <param name="storageName">The storage name.</param>
        /// <param name="assetName">The asset name.</param>
        /// <param name="description">The description of the asset.</param>
        /// <returns>The asset.</returns>
        private static async Task<AssetSchema> CreateOutputAssetAsync(MKIOClient client, string storageName, string assetName, string? description = null)
        {
            // Create an empty output asset

            var outputAsset = await client.Assets.CreateOrUpdateAsync(
                assetName,
                null,
                storageName!,
                description,
                AssetContainerDeletionPolicyType.Delete,
                null,
                new Dictionary<string, string> { { "typeAsset", "encoded" } }
                );
            Console.WriteLine($"Output asset '{assetName}' created.");

            return outputAsset;
        }

        /// <summary>
        /// Creates or updates the Transform.
        /// </summary>
        /// <param name="client">The MK.IO client.</param>
        /// <param name="transformName">The transform name.</param>
        /// <param name="encoderPreset">The encoder preset.</param>
        /// <returns>The transform.</returns>
        private static async Task<TransformSchema> CreateOrUpdateTransformAsync(MKIOClient client, string transformName, EncoderNamedPreset encoderPreset)
        {
            // Create or update a transform
            var transform = await client.Transforms.CreateOrUpdateAsync(transformName, new TransformProperties
            {
                Description = $"Encoding with {encoderPreset} preset",
                Outputs =
                [
                    new() {
                        Preset = new BuiltInStandardEncoderPreset(encoderPreset),
                        RelativePriority = TransformOutputPriorityType.Normal
                    }
                ]
            });

            Console.WriteLine($"Transform '{transform.Name}' created/updated.");
            return transform;
        }

        /// <summary>
        /// Creates or updates the text track insertion Transform.
        /// </summary>
        /// <param name="client">The MK.IO client.</param>
        /// <param name="transformName">The transform name.</param>
        /// <returns>The transform.</returns>
        private static async Task<TransformSchema> CreateOrUpdateTransformTextTrackAsync(MKIOClient client, string transformName)
        {
            // https://docs.mk.io/docs/add-a-track-to-a-vod-asset

            var trackInserter = new TextTrack()
            {
                DisplayName = "English",
                LanguageCode = "en-US",
                TrackName = "English",
                PlayerVisibility = TextTrackPlayerVisibility.Visible,
                HlsSettings = new HlsSettings()
                {
                    Characteristics = "public.accessibility.transcribes-spoken-dialog",
                    Default = true,
                    Forced = false
                }
            };

            // Create or update a transform
            var transform = await client.Transforms.CreateOrUpdateAsync(transformName, new TransformProperties
            {
                Description = $"Text track inserter transform",
                Outputs =
                [
                    new() {
                        Preset = new TrackInserterPreset([trackInserter]),
                        RelativePriority = TransformOutputPriorityType.Normal
                    }
                ]
            });

            Console.WriteLine($"Transform '{transform.Name}' created/updated.");
            return transform;
        }

        /// <summary>
        /// Creates or updates the VOD Transcript Transform.
        /// </summary>
        /// <param name="client">The MK.IO client.</param>
        /// <param name="transformName">The transform name.</param>
        /// <returns>The transform.</returns>
        private static async Task<TransformSchema> CreateOrUpdateTransformVodTranscriptAsync(MKIOClient client, string transformName)
        {
            // settings
            var pipelineArgs = new VodPipelineArguments(
                new VodArguments(
                    new List<Transcription> {
                        new("language", "en-US")
                    }
                    ));

            // Create or update a transform
            var transform = await client.Transforms.CreateOrUpdateAsync(transformName, new TransformProperties
            {
                Description = $"VOD Transcript transform",
                Outputs =
                [
                    new() {
                        Preset = new AIPipelinePreset(pipelineArgs),
                        RelativePriority = TransformOutputPriorityType.Normal
                    }
                ]
            });

            Console.WriteLine($"Transform '{transform.Name}' created/updated.");
            return transform;
        }

        /// <summary>
        /// Creates or updates the Transform for thumbnail creation.
        /// </summary>
        /// <param name="client">The MK.IO client.</param>
        /// <param name="transformName">The transform name.</param>
        /// <returns>The transform.</returns>
        private static async Task<TransformSchema> CreateOrUpdateThumbnailTransformAsync(MKIOClient client, string transformName)
        {
            // https://docs.mk.io/docs/thumbnails-generation
            // Sprite configuration
            var thumbnailConfig = new List<ThumbnailGeneratorConfiguration>
            {
                new() {
                    Format = "Jpeg",
                    Start = "PT0S",
                    Range = "100%",
                    Step = "1%",
                    Width = "10%",
                    Height = "10%",
                    SpriteColumn = 10
                }
            };

            // Create or update a transform
            var transform = await client.Transforms.CreateOrUpdateAsync(transformName, new TransformProperties
            {
                Description = $"Thumbnail transform",
                Outputs =
                [
                    new() {
                        Preset = new ThumbnailGeneratorPreset(thumbnailConfig),
                        RelativePriority = TransformOutputPriorityType.Normal
                    }
                ]
            });

            Console.WriteLine($"Transform '{transform.Name}' created/updated.");
            return transform;
        }

        /// <summary>
        /// Submits a request to MK.IO to apply the specified Transform to a given input video.
        /// </summary>
        /// <param name="client">The MK.IO client.</param>
        /// <param name="transformName">The transform name.</param>
        /// <param name="jobName">The job name.</param>
        /// <param name="inputAssetName">The input asset name.</param>
        /// <param name="outputAssetName">The output asset name.</param>
        /// <param name="fileName">The filename in the input asset name.</param>
        /// <returns>The job.</returns>
        private static async Task<JobSchema> SubmitJobAsync(MKIOClient client, string transformName, string jobName, string inputAssetName, string outputAssetName, string? inputFileName)
        {
            // Create the encoding job
            var encodingJob = await client.Jobs.CreateAsync(
                transformName,
                jobName,
                new JobProperties
                {
                    Description = $"My job which encodes '{inputAssetName}' to '{outputAssetName}' with '{transformName}' transform.",
                    Priority = JobPriorityType.Normal,
                    Input = new JobInputAsset(
                       inputAssetName,
                       [
                           inputFileName != null ? Path.GetFileName(inputFileName): ""
                       ]),
                    Outputs =
                    [
                       new JobOutputAsset()
                       {
                           AssetName = outputAssetName
                       }
                    ]
                }
                );
            Console.WriteLine($"Processing job '{encodingJob.Name}' submitted.");
            return encodingJob;
        }

        /// <summary>
        /// Creates a streaming locator on the asset.
        /// </summary>
        /// <param name="client">The MK.IO client.</param>
        /// <param name="outputAssetName">The output asset name.</param>
        /// <param name="locatorName">The locator name.</param>
        /// <returns>The streaming locator.</returns>
        private static async Task<StreamingLocatorSchema> CreateStreamingLocatorAsync(MKIOClient client, string outputAssetName, string locatorName)
        {
            return await client.StreamingLocators.CreateAsync(
                 locatorName,
                 new StreamingLocatorProperties
                 {
                     AssetName = outputAssetName,
                     StreamingPolicyName = PredefinedStreamingPolicy.ClearStreamingOnly
                 });
        }

        /// <summary>
        /// Lists the streaming endpoint(s) and proposes to create one if there is none.
        /// </summary>
        /// <param name="client">The MK.IO client.</param>
        /// <returns>The name of the streaming endpoint created, otherwise null.</returns>
        private static async Task<string?> ListStreamingEndpointsAndCreateOneIfNeededAsync(MKIOClient client)
        {
            string? createdStreamingEndpointName = null;
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
                string? response;
                do
                {
                    Console.WriteLine("No streaming endpoint found. Do you want to create one and start it? (y/n)");
                    response = Console.ReadLine();

                } while (response != "Y" && response != "N" && response != "y" && response != "n");

                if (response == "Y" || response == "y")
                {
                    var locationToUse = await client.Account.GetSubscriptionLocationAsync();
                    if (locationToUse != null)
                    {
                        var streamingEndpoint = await client.StreamingEndpoints.CreateAsync(
                           MKIOClient.GenerateUniqueName("endpoint"),
                           locationToUse.Name,
                           new StreamingEndpointProperties
                           {
                               Description = "Streaming endpoint created by sample"
                           },
                           true
                           );
                        createdStreamingEndpointName = streamingEndpoint.Name;
                        Console.WriteLine($"Streaming endpoint '{streamingEndpoint.Name}' created and starting.");
                    }
                    else
                    {
                        Console.WriteLine("Error. No location found. Cannot create the streaming endpoint.");
                    }
                    Console.WriteLine();
                }
            }
            return createdStreamingEndpointName;
        }

        /// <summary>
        /// Lists the streaming Urls for a specified locator name.
        /// </summary>
        /// <param name="client">The MK.IO client.</param>
        /// <param name="locatorName">The locator name.</param>
        /// <returns></returns>
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
                        Console.WriteLine($"      Test player url: " + string.Format(_bitmovinPlayer, path.StreamingProtocol.ToString().ToLower(), Uri.EscapeDataString("https://" + se.Properties.HostName + p)));
                    }
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Polls MK.IO for the status of the Job.
        /// </summary>
        /// <param name="client">The MK.IO client.</param>
        /// <param name="transformName">The transform name.</param>
        /// <param name="jobName">The job name.</param>
        /// <returns>The job when processing is finished/failed/cancelled.</returns>
        private static async Task<JobSchema> WaitForJobToFinishAsync(MKIOClient client, string transformName, string jobName)
        {
            Console.WriteLine();
            const int SleepIntervalMs = 10 * 1000;
            JobSchema job;

            do
            {
                await Task.Delay(SleepIntervalMs);
                job = await client.Jobs.GetAsync(transformName, jobName);
                Console.WriteLine($"State: {job.Properties.State}" + (job.Properties.Outputs.First().Progress != null ? $" Progress: {job.Properties.Outputs.First().Progress}%" : string.Empty));
            }
            while (job.Properties.State == JobState.Queued || job.Properties.State == JobState.Scheduled || job.Properties.State == JobState.Processing);

            Console.WriteLine();
            return job;
        }

        /// <summary>
        /// Display information about a job completed (finished, cancelled or failed).
        /// </summary>
        /// <param name="job">The job which is finished.</param>
        private static void DisplayJobStatusWhenCompleted(JobSchema job)
        {
            if (job.Properties.State == JobState.Error)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Job failed.");
                if (job.Properties.Outputs.First() != null && job.Properties.Outputs.First().Error.Message != null)
                {
                    Console.WriteLine(job.Properties.Outputs.First().Error.Message);
                }
            }
            else if (job.Properties.State == JobState.Canceled)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Job cancelled.");
            }
            else if (job.Properties.State == JobState.Finished)
            {
                Console.WriteLine("Job finished.");
            }
            Console.ResetColor();
        }

        /// <summary>
        /// Creates a download locator on the asset.
        /// </summary>
        /// <param name="client">The MK.IO client.</param>
        /// <param name="outputAssetName">The output asset name.</param>
        /// <param name="locatorName">The locator name.</param>
        /// <returns>The streaming locator.</returns>
        private static async Task<StreamingLocatorSchema> CreateDownloadLocatorAsync(MKIOClient client, string outputAssetName, string locatorName)
        {
            return await client.StreamingLocators.CreateAsync(
                 locatorName,
                 new StreamingLocatorProperties
                 {
                     AssetName = outputAssetName,
                     StreamingPolicyName = PredefinedStreamingPolicy.DownloadOnly
                 });
        }

        /// <summary>
        /// Lists the download Urls for a specified locator name.
        /// </summary>
        /// <param name="client">The MK.IO client.</param>
        /// <param name="locatorName">The locator name.</param>
        /// <returns></returns>
        private static async Task ListDownloadUrlsAsync(MKIOClient client, string locatorName)
        {
            // list Streaming Endpoints
            var streamingEndpoints = await client.StreamingEndpoints.ListAsync();

            // List the streaming Url
            var paths = await client.StreamingLocators.ListUrlPathsAsync(locatorName);
            Console.WriteLine($"Download Urls for locator '{locatorName}' :");
            foreach (var path in paths.DownloadPaths)
            {
                foreach (var se in streamingEndpoints)
                {
                    Console.WriteLine($"      Url : https://{se.Properties.HostName}{path}");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Cleans the created resources if user accepts.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="assetNames"></param>
        /// <param name="transformAndjobNames"></param>
        /// <param name="streamingEndpoint"></param>
        /// <returns></returns>
        private static async Task CleanIfUserAcceptsAsync(MKIOClient client, List<string> assetNames, List<(string, string)> transformAndjobNames, string? streamingEndpoint = null)
        {
            string? response;
            do
            {
                Console.WriteLine("Do you want to clean the created resources (assets, job, etc) ? (y/n)");
                response = Console.ReadLine();

            } while (response != "Y" && response != "N" && response != "y" && response != "n");

            if (response == "Y" || response == "y")
            {
                foreach (var assetName in assetNames)
                {
                    try
                    {
                        await client.Assets.DeleteAsync(assetName);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Unexpected error deleting asset '{assetName}'. Error: {ex.Message}");
                    }
                }

                foreach (var transformAndjobName in transformAndjobNames)
                {
                    try
                    {
                        await client.Jobs.DeleteAsync(transformAndjobName.Item1, transformAndjobName.Item2);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error deleting job '{transformAndjobName.Item2}'. Error: {ex.Message}");
                    }

                    try
                    {
                        await client.Transforms.DeleteAsync(transformAndjobName.Item1);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error deleting transform '{transformAndjobName.Item1}'. Error: {ex.Message}");
                    }
                }

                if (streamingEndpoint != null)
                    try
                    {
                        await client.StreamingEndpoints.DeleteAsync(streamingEndpoint);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error deleting streaming endpoint '{streamingEndpoint}'. Error: {ex.Message}");
                    }
                Console.WriteLine("Cleaning done.");
            }
        }
    }
}