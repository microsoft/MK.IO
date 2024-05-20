// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;

namespace MK.IO.Models
{
    public partial class SubscriptionListResponseSchema
    {
        public static SubscriptionListResponseSchema FromJson(string json)
        {
            return JsonConvert.DeserializeObject<SubscriptionListResponseSchema>(json, ConverterLE.Settings) ?? throw new Exception("Error with subscription list deserialization");
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, ConverterLE.Settings);
        }

        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("items")]
        public List<SubscriptionResponseSchema> Items { get; set; }
    }
}