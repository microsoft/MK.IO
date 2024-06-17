// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Microsoft.Extensions.Configuration;
using MK.IO;
using MK.IO.Models;

namespace Sample
{
    /// <summary>
    /// Sample code for MK.IO using MK.IO .NET SDK that does the following
    /// - create a live event
    /// - create a live output asset
    /// - create a live output
    /// - create a locator
    /// - create and start a streaming endpoint if there is none
    /// - list the streaming urls and test player urls.
    /// - clean the created resources if the user accepts
    /// </summary>

    public class SimpleLiveStreaming
    {
        private const string _bitmovinPlayer = "https://bitmovin.com/demos/stream-test?format={0}&manifest={1}";

        public static async Task RunAsync()
        {
            /* you need to add an appsettings.json file with the following content:
             {
                "MKIOSubscriptionName": "yourMKIOsubscriptionname",
                "MKIOToken": "yourMKIOtoken",
                "StorageName":"yourStorageName"
             }
            */

            Console.WriteLine("Sample that creates a live event and live output with MK.IO and publishes the output asset for clear streaming.");

            // Load settings from the appsettings.json file and check them
            IConfigurationRoot config = LoadAndCheckSettings();

            // Creating a unique suffix so that we don't have name collisions if you run the sample
            // multiple times without cleaning up.
            string uniqueId = MKIOClient.GenerateUniqueName(string.Empty);
            string liveEventName = $"liveevent-{uniqueId}";
            string outputAssetName = $"asset-{uniqueId}";
            string liveOutputName = $"liveoutput-{uniqueId}";
            string locatorName = $"locator-{uniqueId}";

            // MK.IO Client creation
            var client = new MKIOClient(config["MKIOSubscriptionName"]!, config["MKIOToken"]!);

            // Create a live event
            _ = await CreateLiveEventAsync(client, liveEventName);

            // Create a live output asset
            _ = await client.Assets.CreateOrUpdateAsync(outputAssetName, null, config["StorageName"]!, "live output asset", AssetContainerDeletionPolicyType.Delete);

            // Create a live output
            _ = await CreateLiveOutputAsync(client, liveEventName, liveOutputName, outputAssetName);

            // start the live event and display urls
            await StartLiveEventAndDisplayUrlsAsync(client, liveEventName);

            // Create a locator for clear streaming
            _ = await CreateStreamingLocatorAsync(client, outputAssetName, locatorName);

            // List the streaming endpoint(s) and propose creation if needed
            var createdEndpoint = await ListStreamingEndpointsAndCreateOneIfNeededAsync(client);

            // Display streaming paths and test player urls
            await ListStreamingUrlsAsync(client, locatorName);

            // Clean up of resources
            await CleanIfUserAcceptsAsync(client, outputAssetName, liveEventName, liveOutputName, createdEndpoint);
        }

        /// <summary>
        /// Starts the live event and displays useful urls.
        /// </summary>
        /// <param name="client">The MK.IO client.</param>
        /// <param name="liveEventName">The live event name.<param>
        /// <returns></returns>
        private static async Task StartLiveEventAndDisplayUrlsAsync(MKIOClient client, string liveEventName)
        {
            Console.WriteLine();
            Console.WriteLine("Press ENTER to start the live event (billing will occur)");
            Console.ReadLine();

            Console.WriteLine($"Starting the live event: '{liveEventName}'.");
            await client.LiveEvents.StartAsync(liveEventName, true);

            // Refresh the live event object to get URLs
            var liveEvent = await client.LiveEvents.GetAsync(liveEventName);
            Console.WriteLine($"Live Event ingest url: {liveEvent.Properties.Input.Endpoints.First().Url}/stream");
            Console.WriteLine($"Live Event preview url: {liveEvent.Properties.Preview.Endpoints.First().Url}");
            Console.WriteLine($"Live Event preview test player url: " + string.Format(_bitmovinPlayer, liveEvent.Properties.Preview.Endpoints.First().Protocol.ToString().ToLower(), liveEvent.Properties.Preview.Endpoints.First().Url));
            Console.WriteLine();
            Console.WriteLine("Please connect your RTMP encoder to the ingest URL (press ENTER when done or to continue)");
            Console.ReadLine();
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
        /// Creates a live event.
        /// </summary>
        /// <param name="client">The MK.IO client.</param>
        /// <param name="liveEventName">The live event name.<param>
        /// <returns>The live event.</returns>
        private static async Task<LiveEventSchema> CreateLiveEventAsync(MKIOClient client, string liveEventName)
        {
            // Create a live event
            LiveEventSchema liveEvent;

            var locationName = await ReturnLocationNameOfSubscriptionAsync(client);

            if (locationName != null)
            {
                liveEvent = await client.LiveEvents.CreateAsync(liveEventName, locationName, new LiveEventProperties
                {
                    Input = new LiveEventInput { StreamingProtocol = LiveEventInputProtocol.RTMP },
                    StreamOptions = ["Default"],
                    Encoding = new LiveEventEncoding { EncodingType = LiveEventEncodingType.PassthroughBasic }
                });
                Console.WriteLine($"Live Event '{liveEventName}' created.");
            }
            else
            {
                Console.WriteLine("Error. No location found. Cannot create the live event.");
                throw (new Exception("No location found. Cannot create the live event."));
            }

            return liveEvent;
        }

        /// <summary>
        /// Returns the location name of the subscription
        /// </summary>
        /// <param name="client">The MK.IO client.</param>
        /// <returns>The name of the location, otherwise null.</returns>
        private static async Task<string?> ReturnLocationNameOfSubscriptionAsync(MKIOClient client)
        {
            var sub = await client.Account.GetSubscriptionAsync();
            var locs = await client.Account.ListAllLocationsAsync();
            var locationOfSub = locs.FirstOrDefault(l => l.Metadata.Id == sub.Spec.LocationId);

            return locationOfSub?.Metadata.Name;
        }

        /// <summary>
        /// Creates a live ouput.
        /// </summary>
        /// <param name="client">The MK.IO client.</param>
        /// <param name="liveOutputName">The live output name.<param>
        /// <param name="liveOutputName">The live output name.<param>
        /// <returns>The live output.</returns>
        private static async Task<LiveOutputSchema> CreateLiveOutputAsync(MKIOClient client, string liveEventName, string liveOutputName, string outputAssetName)
        {
            // Create a live output
            var liveOutput = await client.LiveOutputs.CreateAsync(liveEventName, liveOutputName, new LiveOutputProperties
            {
                ArchiveWindowLength = new TimeSpan(0, 5, 0),
                AssetName = outputAssetName
            });
            Console.WriteLine($"Live Output '{liveOutputName}' created.");

            return liveOutput;
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
                Console.WriteLine("No streaming endpoint found. Do you want to create one and start it? (Y/N)");
                var response = Console.ReadLine();
                if (response == "Y" || response == "y")
                {
                    var locationToUse = await ReturnLocationNameOfSubscriptionAsync(client);
                    if (locationToUse != null)
                    {
                        var streamingEndpoint = await client.StreamingEndpoints.CreateAsync(
                           MKIOClient.GenerateUniqueName("endpoint"),
                           locationToUse,
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
        /// Cleans the created resources if user accepts.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="outputAssetName"></param>
        /// <param name="liveOutputName"></param>
        /// <param name="liveEventName"></param>
        /// <param name="streamingEndpoint"></param>
        /// <returns></returns>
        private static async Task CleanIfUserAcceptsAsync(MKIOClient client, string outputAssetName, string liveEventName, string liveOutputName, string? streamingEndpoint = null)
        {
            string? response = null;
            do
            {
                Console.WriteLine("Do you want to clean the created resources (asset, live event, live output, etc) ? (y/n)");
                response = Console.ReadLine();

            } while (response != "Y" && response != "N" && response != "y" && response != "n");

            if (response == "Y" || response == "y")
            {

                try
                {
                    await client.LiveOutputs.DeleteAsync(liveEventName, liveOutputName);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deleting live output '{liveOutputName}'. Error: {ex.Message}");
                }

                try
                {
                    await client.Assets.DeleteAsync(outputAssetName);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deleting asset '{outputAssetName}'. Error: {ex.Message}");
                }

                try
                {
                    await client.LiveEvents.DeleteAsync(liveEventName);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deleting live event '{liveEventName}'. Error: {ex.Message}");
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
