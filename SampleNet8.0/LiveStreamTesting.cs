// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Microsoft.Extensions.Configuration;
using MK.IO;
using MK.IO.Models;

namespace Sample
{
    public class ProgramLiveTesting
    {
        public static async Task LiveStreamTesting()
        {
            Console.WriteLine("Live testing that operates MK.IO.");

            /* you need to add an appsettings.json file with the following content:
             {
                "MKIOSubscriptionName": "yourMKIOsubscriptionname",
                "MKIOToken": "yourMKIOtoken",
                "Location":"yourLocation",
                "StorageName":"yourStorageName"
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

            MKIOClient.GenerateUniqueName("asset");

            UserInfo profile;
            try
            {
                profile = await client.Account.GetUserProfileAsync();
            }
            catch (ApiException ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
            }

            // *******************
            // Live event operations
            // *******************
            var liveEventName = MKIOClient.GenerateUniqueName("liveEvent");
            var le = await client.LiveEvents.CreateAsync(liveEventName, config["Location"], new LiveEventProperties
            {
                Input = new LiveEventInput { StreamingProtocol = LiveEventInputProtocol.RTMP },
                StreamOptions = ["Default"],
                Encoding = new LiveEventEncoding { EncodingType = LiveEventEncodingType.PassthroughBasic }
            });

            Console.WriteLine($"Live Event Created: {liveEventName}");

            // Create live output asset
            var nameasset = MKIOClient.GenerateUniqueName("liveoutput");
            var loasset = await client.Assets.CreateOrUpdateAsync(nameasset, "asset-" + nameasset, config["StorageName"], "live output asset");

            // Create live output
            var liveOutput = await client.LiveOutputs.CreateAsync(le.Name, MKIOClient.GenerateUniqueName("liveOutput"), new LiveOutputProperties
            {
                ArchiveWindowLength = new TimeSpan(0, 5, 0),
                AssetName = nameasset
            });

            Console.WriteLine($"Live Output Created: {liveOutput.Name}");

            // List live outputs
            var los = client.LiveOutputs.List(le.Name);
            foreach (var output in los)
            {
                Console.WriteLine($"Live Output: {output.Name}");
            }

            // Streaming endpoint operations (optional, if you need to manage streaming endpoints)
            var mkses = client.StreamingEndpoints.List();
            foreach (var se in mkses)
            {
                Console.WriteLine($"Streaming Endpoint: {se.Name}");
            }

            // Clean up of resources

            // Delete live output
            await client.LiveOutputs.DeleteAsync(liveEventName, liveOutput.Name);
            Console.WriteLine($"Live Output Deleted: {liveOutput.Name}");

            // Stop the live event
            await client.LiveEvents.StopAsync(liveEventName);
            Console.WriteLine($"Live Event Stopped: {liveEventName}");

            // Delete the live event
            await client.LiveEvents.DeleteAsync(liveEventName);
            Console.WriteLine($"Live Event Deleted: {liveEventName}");

        }
    }
}
