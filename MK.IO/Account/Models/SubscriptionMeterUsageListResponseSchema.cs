// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;

namespace MK.IO.Models
{
    public partial class SubscriptionMeterUsageListResponseSchema
    {
        public static SubscriptionMeterUsageListResponseSchema FromJson(string json)
        {
            return JsonConvert.DeserializeObject<SubscriptionMeterUsageListResponseSchema>(json, ConverterLE.Settings) ?? throw new Exception("Error with subscription usage deserialization");
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, ConverterLE.Settings);
        }

        [JsonProperty("Kind")]
        public string Kind { get; set; }

        [JsonProperty("metadata")]
        public SubscriptionMeterUsageMetadataSchema Metadata { get; set; }

        [JsonProperty("spec")]
        public SubscriptionMeterUsageSpecSchema Spec { get; set; }
    }
}