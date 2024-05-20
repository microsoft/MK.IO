// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json;
using System.Text.Json.Serialization;

namespace MK.IO.Models
{
    public class SubscriptionResponseSchema
    {
        public static SubscriptionResponseSchema FromJson(string json)
        {
            return JsonSerializer.Deserialize<SubscriptionResponseSchema>(json, ConverterLE.Settings) ?? throw new Exception("Error with subscription deserialization");
        }

        public string ToJson()
        {
            return JsonSerializer.Serialize(this, ConverterLE.Settings);
        }

        public MetadataSubscription Metadata { get; set; }

        public SubscriptionSchema Spec { get; set; }
    }

    public class MetadataSubscription
    {
        public Guid Id { get; set; }

        [JsonInclude]
        public DateTime? Created { get; private set; }

        public DateTime Updated { get; set; }
    }
}