// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json;
using System.Text.Json.Serialization;

namespace MK.IO.Models
{
    public partial class AccountStats
    {
        public static AccountStats FromJson(string json)
        {
            return JsonSerializer.Deserialize<AccountStats>(json, ConverterLE.Settings) ?? throw new Exception("Error with account stats deserialization");
        }

        public string ToJson()
        {
            return JsonSerializer.Serialize(this, ConverterLE.Settings);
        }


        public Assets Assets { get; set; }

        public ContentKeyPolicies ContentKeyPolicies { get; set; }

        public Extra Extra { get; set; }

        public LiveEvents LiveEvents { get; set; }

        public StorageAccounts StorageAccounts { get; set; }

        public StreamingEndpoints StreamingEndpoints { get; set; }

        public StreamingLocators StreamingLocators { get; set; }

        public StreamingPolicies StreamingPolicies { get; set; }
    }

    public class Assets
    {
        public int Total { get; set; }
    }

    public class ContentKeyPolicies
    {
        public int Total { get; set; }
    }

    public class Extra
    {
        [JsonPropertyName("subscription_id")]
        public Guid SubscriptionId { get; set; }
    }

    public class LiveEvents
    {
        public int Running { get; set; }

        public int Stopped { get; set; }

        public int Total { get; set; }
    }


    public class StorageAccounts
    {
        public int Total { get; set; }
    }

    public class StreamingEndpoints
    {
        public int Running { get; set; }

        public int Stopped { get; set; }

        public int Total { get; set; }
    }

    public class StreamingLocators
    {
        public int Total { get; set; }
    }

    public class StreamingPolicies
    {
        public int Total { get; set; }
    }
}