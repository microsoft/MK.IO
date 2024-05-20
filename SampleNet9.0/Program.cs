// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.Configuration;
using MK.IO;
using MK.IO.Models;
using System.Security.Cryptography;

namespace Sample
{
    internal class Program
    {
        static void Main()
        {
            // MainAsync().Wait();
            // or, if you want to avoid exceptions being wrapped into AggregateException:
            MainAsync().GetAwaiter().GetResult();
        }


        static async Task MainAsync()
        {
            Console.WriteLine("Sample that operates MK.IO.");

            /* you need to add an appsettings.json file with the following content:
             {
                "MKIOSubscriptionName": "yourMKIOsubscriptionname",
                "MKIOToken": "yourMKIOtoken"
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
                profile = client.Account.GetUserProfile();
            }
            catch (ApiException ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
            }

            //var myck = client.ContentKeyPolicies.Get("keypolicy-aes");
            var myck2 = client.ContentKeyPolicies.Get("keypolicy-17c7ed160f");

            var cks2 = client.ContentKeyPolicies.List();


            // Get subscription stats
            var stats = client.Account.GetSubscriptionStats();

            var subs = await client.Account.ListAllSubscriptionsAsync();
            var sub = await client.Account.GetSubscriptionAsync();
            var locs = await client.Account.ListAllLocationsAsync();

            // *****************
            // asset operations
            // *****************

            // list assets

            var mkioAssetsResult2 = client.Assets.List(null, "name gt 'ignite-t'", null, top: 3);

            var mkioAssetsResult = client.Assets.ListAsPage("properties/created desc", null, null, null, 10);
            while (true)
            {
                foreach (var a in mkioAssetsResult.Results)
                {
                    Console.WriteLine(a.Name);
                }
                if (mkioAssetsResult.NextPageLink == null) break;
                mkioAssetsResult = client.Assets.ListAsPageNext(mkioAssetsResult.NextPageLink);
            }

            // list encoded assets (using labels)
            var encodedAssets = client.Assets.List(label: new List<string> { "typeAsset=encoded" });

            var specc = client.Assets.ListTracksAndDirListing("ignite-truncated-StandardEncoder-H264SingleBitrate720p-98b7c74252");

            // get streaming locators for asset
            try
            {
                var locatorsAsset = client.Assets.ListStreamingLocators("ignite-truncated-StandardEncoder-H264SingleBitrate720p-98b7c74252");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            // get asset
            var mkasset = client.Assets.Get("ignite-truncated-StandardEncoder-H264SingleBitrate720p-98b7c74252");

            // create asset
            /*
            var newasset = client.Assets.CreateOrUpdate(
                "uploaded-5143a7c39a-copy-7947d5ccac",
                "asset-d56fa44c-c5d5-47db-aa4b-16686ffa3d3b",
                "amsxpfrstorage",
                "description of asset copy",
                AssetContainerDeletionPolicyType.Retain,
                null,
                new Dictionary<string, string>() { { "typeAsset", "source" } }
                );
            */

            // delete asset
            // client.Assets.Delete("asset-33adc1873f");

            // *****************************
            // Streaming locator operations
            // *****************************


            // standard list
            var mkioLocators = await client.StreamingLocators.ListAsync();
            var locator = mkioLocators.Where(l => l.Properties.StreamingLocatorId == new Guid("{e879fe57-6354-46fc-b817-11a16ffd1672}")).FirstOrDefault();
            if (locator != null)
            {
                // locator was found
            }

            // list using pages of 10
            var mkioSLocsResult = client.StreamingLocators.ListAsPage("properties/created desc", null, 20);
            while (true)
            {
                foreach (var a in mkioSLocsResult.Results)
                {
                    Console.WriteLine(a.Name);
                }
                if (mkioSLocsResult.NextPageLink == null) break;

                mkioSLocsResult = client.StreamingLocators.ListAsPageNext(mkioSLocsResult.NextPageLink);
            }

            // standard list
            var mklocators = client.StreamingLocators.List();

            // listing using a filter and sorting
            var mklocatorsf = client.StreamingLocators.List("properties/created desc", "name eq 'clear'");

            //var mklocator1 = client.StreamingLocators.Get("locator-25452");

            var mklocator2 = client.StreamingLocators.Create(
               MKIOClient.GenerateUniqueName("locator"),
               new StreamingLocatorProperties
               {
                   AssetName = "ignite-truncated-out123-encodedmkio",
                   StreamingPolicyName = PredefinedStreamingPolicy.ClearStreamingOnly,
                   StartTime = DateTime.UtcNow,
                   EndTime = DateTime.UtcNow.AddHours(2)
               });

            var pathsl = client.StreamingLocators.ListUrlPaths(mklocator2.Name);

            // client.StreamingLocators.Delete("locator-25452");

            // ****************************
            // Streaming policy operations
            // ****************************

            // list using pages of 10
            var mkioSPolsResult = client.StreamingPolicies.ListAsPage("properties/created desc", null, 2);
            while (true)
            {
                foreach (var a in mkioSPolsResult.Results)
                {
                    Console.WriteLine(a.Name);
                }
                if (mkioSPolsResult.NextPageLink == null) break;

                mkioSPolsResult = client.StreamingPolicies.ListAsPageNext(mkioSPolsResult.NextPageLink);
            }
            // standard list
            var mkstreampol = client.StreamingPolicies.List();

            // listing using a filter and sorting
            var mkstreampolf = client.StreamingPolicies.List("properties/created desc", "name eq 'Predefined_ClearKey'");

            //var mklocator1 = client.StreamingPolicies.Get("locator-25452");


            // ******************************
            // content key policy operations
            // ******************************

            try
            {
                var ck = client.ContentKeyPolicies.Get("testpolcreate");
            }

            catch
            {

            }


            try
            {
                await client.ContentKeyPolicies.DeleteAsync("testpolcreate");
            }

            catch
            {

            }
            var cks = client.ContentKeyPolicies.List();

            var key = GenerateSymKeyAsBase64();

            var newpol = client.ContentKeyPolicies.Create(
                "testpolcreate",
                new ContentKeyPolicyProperties("My description", new List<ContentKeyPolicyOption>()
                {
                    new(
                        "option1",
                        new ContentKeyPolicyWidevineConfiguration("{}"),
                        new ContentKeyPolicyTokenRestriction(
                            "issuer",
                            "audience",
                            RestrictionTokenType.Jwt,
                            new ContentKeyPolicySymmetricTokenKey(key)
                            )
                        )
                })
                );

            var ckpolprop = await client.ContentKeyPolicies.GetPolicyPropertiesWithSecretsAsync("testpolcreate");


            // *******************
            // storage operations
            // *******************

            // Creation

            /*
            var storage = client.StorageAccounts.Create(new StorageSchema
            {
                Name = config["StorageName"],
                Location = config["StorageRegion"],
                Description = "my description",
                AzureStorageConfiguration = new BlobStorageAzureProperties
                {
                    Url = config["StorageSAS"]
                }
            }
            );
            */

            // List
            var storages = client.StorageAccounts.List();

            // Get
            var storage2 = client.StorageAccounts.Get((Guid)storages.First().Metadata.Id);

            // Update the description
            storage2.Spec.Description = "my new description";
            var stor3 = client.StorageAccounts.Update((Guid)storage2.Metadata.Id, storage2.Spec);

            var creds = client.StorageAccounts.ListCredentials((Guid)storage2.Metadata.Id);

            // var cred = client.StorageAccounts.GetCredential((Guid)storages.First().Metadata.Id, (Guid)creds.First().Metadata.Id);

            // client.StorageAccounts.DeleteCredential((Guid)storages.First().Metadata.Id, (Guid)creds.First().Metadata.Id);

            /*
            var cred = client.StorageAccounts.CreateCredential((Guid)storage2.Metadata.Id, new CredentialSchema
            {
                AzureCredential = new AzureCredential
                {
                    SasToken = "mySasToken"
                }
            });
            */

            // Delete
            // client.StorageAccounts.Delete(storages.First().Metadata.Id);




            // ************************
            // asset filter operations
            // ************************

            var assetFilters = client.AssetFilters.List("ignite-truncated-StandardEncoder-H264SingleBitrate720p-98b7c74252");

            assetFilters.ToList().ForEach(af => client.AssetFilters.Delete("ignite-truncated-StandardEncoder-H264SingleBitrate720p-98b7c74252", af.Name));
            //var assetFilter1 = client.AssetFilters.Get("liveoutput-c4debfe5", assetFilters.First().Name);

            // asset filter creation
            // Typically, you will want to select a matching Type, such as Video, and then select additional filters.
            // For instance, to include all audio tracks with mp4a, and all video tracks that are between 0 and 1 Mbps, you would provide these FilterTrackSelection objects:

            var assetFilter = client.AssetFilters.CreateOrUpdate("ignite-truncated-StandardEncoder-H264SingleBitrate720p-98b7c74252", MKIOClient.GenerateUniqueName("filter"), new MediaFilterProperties
            {
                PresentationTimeRange = new PresentationTimeRange
                {
                    Timescale = 10000000,
                },
                Tracks = new List<FilterTrackSelection>()
                {
                    new() {
                        TrackSelections = new List<FilterTrackPropertyCondition>()
                        {
                            new() {
                                Property = FilterTrackPropertyType.Type,
                                Operation = FilterTrackPropertyCompareOperation.Equal,
                                Value = FilterTrackPropertyTypeValue.Video
                            },
                            new() {
                                Property = FilterTrackPropertyType.Bitrate,
                                Operation = FilterTrackPropertyCompareOperation.Equal,
                                Value = "0-1048576"
                            }
                        },
                    },
                    new() {
                        TrackSelections = new List<FilterTrackPropertyCondition>()
                        {
                            new() {
                                Property = FilterTrackPropertyType.Type,
                                Operation = FilterTrackPropertyCompareOperation.Equal,
                                Value = FilterTrackPropertyTypeValue.Audio
                            },
                            new() {
                                Property = FilterTrackPropertyType.FourCC,
                                Operation = FilterTrackPropertyCompareOperation.Equal,
                                Value = "mp4a"
                            }
                        }
                    }
                }
            });

            client.AssetFilters.Delete("ignite-truncated-StandardEncoder-H264SingleBitrate720p-98b7c74252", assetFilter.Name);

            // **************************
            // account filter operations
            // **************************

            var acfilters = client.AccountFilters.List();

            // account filter creation
            // Typically, you will want to select a matching Type, such as Video, and then select additional filters.
            // For instance, to include all audio tracks with mp4a, and all video tracks that are between 0 and 1 Mbps, you would provide these FilterTrackSelection objects:

            var filter = client.AccountFilters.CreateOrUpdate(MKIOClient.GenerateUniqueName("acc-filter"), new MediaFilterProperties
            {
                PresentationTimeRange = new PresentationTimeRange
                {
                    Timescale = 10000000,
                },
                Tracks = new List<FilterTrackSelection>()
                {
                    new() {
                        TrackSelections = new List<FilterTrackPropertyCondition>()
                        {
                            new() {
                                Property = FilterTrackPropertyType.Type,
                                Operation = FilterTrackPropertyCompareOperation.Equal,
                                Value = FilterTrackPropertyTypeValue.Video
                            },
                            new() {
                                Property = FilterTrackPropertyType.Bitrate,
                                Operation = FilterTrackPropertyCompareOperation.Equal,
                                Value = "0-1048576"
                            }
                        },
                    },
                    new() {
                        TrackSelections = new List<FilterTrackPropertyCondition>()
                        {
                            new() {
                                Property = FilterTrackPropertyType.Type,
                                Operation = FilterTrackPropertyCompareOperation.Equal,
                                Value = FilterTrackPropertyTypeValue.Audio
                            },
                            new() {
                                Property = FilterTrackPropertyType.FourCC,
                                Operation = FilterTrackPropertyCompareOperation.Equal,
                                Value = FilterTrackPropertyFourCCValue.mp4a
                            }
                        }
                    }
                }
            });

            client.AccountFilters.Delete(filter.Name);


            // *********************
            // transform operations
            // *********************

            var tranform = client.Transforms.CreateOrUpdate("CVQ720pTransform", new TransformProperties
            {
                Description = "desc",
                Outputs = new List<TransformOutput>
                {
                    new() {
                        Preset = new BuiltInStandardEncoderPreset(EncoderNamedPreset.H264MultipleBitrate720pWithCVQ),
                        RelativePriority = TransformOutputPriorityType.Normal
                    }
                }
            });

            // ***************
            // job operations
            // ***************

            // var jobs = client.Jobs.ListAll();

            // var job = client.Jobs.Get("simple", "testjob1");


            //var outputAsset = client.Assets.CreateOrUpdate("outputasset-012", "asset-outputasset-012", config["StorageName"], "output asset for job");

            /*
            client.Jobs.Create("simple", "testjob2", new JobProperties
            {
                Description = "My job",
                Priority = "Normal",
                Input = new JobInputAsset(
                    "copy-ef2058b692-copy",
                    new List<string> {
                        "switch_1920x1080_AACAudio_3677.mp4"
                    }),
                Outputs = new List<JobOutputAsset>()
                {
                    new JobOutputAsset()
                    {
                        AssetName="outputasset-012"
                    }
                }
            }
            );
            */

            var outputAssetName = MKIOClient.GenerateUniqueName("output");
            var dicLabels = new Dictionary<string, string>
            {
                { "typeAsset", "encoded" },
                { "audience", "public" }
            };
            var outputAsset2 = client.Assets.CreateOrUpdate(outputAssetName, "mkioasset-" + outputAssetName, config["StorageName"]!, "output asset for job", AssetContainerDeletionPolicyType.Retain, null, dicLabels);

            var jobHttp = client.Jobs.Create(tranform.Name, MKIOClient.GenerateUniqueName("job"), new JobProperties
            {
                Description = "My CVQ encoding job",
                Priority = JobPriorityType.Normal,
                Input = new JobInputHttp(
                    null,
                    new List<string> {
                        "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ForBiggerEscapes.mp4"
                    }),
                Outputs = new List<JobOutputAsset>()
                {
                    new()
                    {
                        AssetName = outputAssetName
                    }
                }
            }
            );

            while (jobHttp.Properties.State == JobState.Queued || jobHttp.Properties.State == JobState.Scheduled || jobHttp.Properties.State == JobState.Processing)
            {
                jobHttp = client.Jobs.Get(tranform.Name, jobHttp.Name);
                Console.WriteLine(jobHttp.Properties.State);
                Thread.Sleep(10000);
            }

            //client.Jobs.Cancel("simple", "testjob2");
            client.Jobs.Delete(tranform.Name, jobHttp.Name);


            // **********************
            // live event operations
            // **********************

            var les = client.LiveEvents.List();

            // client.LiveEvents.Delete("liveevent4");

            var le = client.LiveEvents.Create(MKIOClient.GenerateUniqueName("liveEvent"), "francecentral", new LiveEventProperties
            {
                Input = new LiveEventInput { StreamingProtocol = LiveEventInputProtocol.RTMP },
                StreamOptions = new List<string> { "Default" },
                Encoding = new LiveEventEncoding { EncodingType = LiveEventEncodingType.PassthroughBasic }
            });

            /* 
            // NOT IMPLEMENTED
            le = client.LiveEvents.Update(le.Name, "francecentral", new LiveEventProperties
            {
                Input = new LiveEventInput { StreamingProtocol = LiveEventInputProtocol.SRT },
                StreamOptions = new List<string> { "Default" },
                Encoding = new LiveEventEncoding { EncodingType = LiveEventEncodingType.PassthroughBasic }
            });
            */

            // **********************
            // live output operations
            // **********************

            // create live output asset
            var nameasset = MKIOClient.GenerateUniqueName("liveoutput");
            var loasset = client.Assets.CreateOrUpdate(nameasset, "asset-" + nameasset, config["StorageName"], "live output asset");

            var lo = client.LiveOutputs.Create(le.Name, MKIOClient.GenerateUniqueName("liveOutput"), new LiveOutputProperties
            {
                ArchiveWindowLength = new TimeSpan(0, 5, 0),
                AssetName = nameasset
            });

            // live outputs listing
            var los = client.LiveOutputs.List(le.Name);

            if (los.ToList().Count == 1)
            {
                var looo = client.LiveOutputs.Get(le.Name, los.First().Name);
            }


            // ******************************
            // Streaming endpoint operations
            // ******************************

            // get streaming endpoint
            var mkse = client.StreamingEndpoints.Get("xpouyatse1");

            // list streaming endpoints
            var mkses = client.StreamingEndpoints.List();

            // create streaming endpoint

            /*
            var newSe = client.StreamingEndpoints.Create("streamingendpoint2", "francecentral", new StreamingEndpointProperties
            {
                Description = "my description",
                ScaleUnits = 0,
                CdnEnabled = false,
                Sku = new StreamingEndpointsCurrentSku
                {
                    Name = StreamingEndpointSkuType.Standard
                }
            });
            */

            // start, stop, delete streaming endpoint
            //client.StreamingEndpoints.Start("streamingendpoint1");
            //client.StreamingEndpoints.Stop("streamingendpoint1");
            //client.StreamingEndpoints.Delete("streamingendpoint2");


        }

        /// <summary>
        /// Generates a random symmetric key as a Base64 string.
        /// </summary>
        /// <returns></returns>
        private static string GenerateSymKeyAsBase64()
        {
            byte[] TokenSigningKey = new byte[40];
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(TokenSigningKey);
            return Convert.ToBase64String(TokenSigningKey);
        }
        /// <summary>
        /// Generate a random string of a given length.
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string RandomString(int length)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[length];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new String(stringChars);
        }
    }
}
