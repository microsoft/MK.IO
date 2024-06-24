// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json;
using System.Text.Json.Serialization;

namespace MK.IO.Models
{
    public partial class SubscriptionMeterUsageListResponseSchema
    {
        public static SubscriptionMeterUsageListResponseSchema FromJson(string json)
        {
            return JsonSerializer.Deserialize<SubscriptionMeterUsageListResponseSchema>(json, ConverterLE.Settings) ?? throw new Exception("Error with subscription usage deserialization");
        }

        public string ToJson()
        {
            return JsonSerializer.Serialize(this, ConverterLE.Settings);
        }

        [JsonPropertyName("Kind")]

        public string Kind { get; set; }

        public SubscriptionMeterUsageMetadataSchema Metadata { get; set; }

        public SubscriptionMeterUsageSpecSchema Spec { get; set; }
    }
}