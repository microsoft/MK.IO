// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;

namespace MK.IO.Models
{
    public partial class AccountStats
    {
        public static AccountStats FromJson(string json)
        {
            return JsonConvert.DeserializeObject<AccountStats>(json, ConverterLE.Settings) ?? throw new Exception("Error with account stats deserialization");
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, ConverterLE.Settings);
        }


        [JsonProperty("assets")]
        public Assets Assets { get; set; }

        [JsonProperty("contentKeyPolicies")]
        public ContentKeyPolicies ContentKeyPolicies { get; set; }

        [JsonProperty("extra")]
        public Extra Extra { get; set; }

        [JsonProperty("liveEvents")]
        public LiveEvents LiveEvents { get; set; }

        [JsonProperty("storageAccounts")]
        public StorageAccounts StorageAccounts { get; set; }

        [JsonProperty("streamingEndpoints")]
        public StreamingEndpoints StreamingEndpoints { get; set; }

        [JsonProperty("streamingLocators")]
        public StreamingLocators StreamingLocators { get; set; }

        [JsonProperty("streamingPolicies")]
        public StreamingPolicies StreamingPolicies { get; set; }
    }

    public class Assets
    {
        [JsonProperty("total")]
        public int Total { get; set; }
    }

    public class ContentKeyPolicies
    {
        [JsonProperty("total")]
        public int Total { get; set; }
    }

    public class Extra
    {
        [JsonProperty("subscription_id")]
        public Guid SubscriptionId { get; set; }
    }

    public class LiveEvents
    {
        [JsonProperty("running")]
        public int Running { get; set; }

        [JsonProperty("stopped")]
        public int Stopped { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }
    }


    public class StorageAccounts
    {
        [JsonProperty("total")]
        public int Total { get; set; }
    }

    public class StreamingEndpoints
    {
        [JsonProperty("running")]
        public int Running { get; set; }

        [JsonProperty("stopped")]
        public int Stopped { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }
    }

    public class StreamingLocators
    {
        [JsonProperty("total")]
        public int Total { get; set; }
    }

    public class StreamingPolicies
    {
        [JsonProperty("total")]
        public int Total { get; set; }
    }
}