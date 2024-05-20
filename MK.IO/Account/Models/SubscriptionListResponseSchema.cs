// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json;

namespace MK.IO.Models
{
    public partial class SubscriptionListResponseSchema
    {
        public static SubscriptionListResponseSchema FromJson(string json)
        {
            return JsonSerializer.Deserialize<SubscriptionListResponseSchema>(json, ConverterLE.Settings) ?? throw new Exception("Error with subscription list deserialization");
        }

        public string ToJson()
        {
            return JsonSerializer.Serialize(this, ConverterLE.Settings);
        }

        public string Kind { get; set; }

        public List<SubscriptionResponseSchema> Items { get; set; }
    }
}