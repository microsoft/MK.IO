// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;

namespace MK.IO.Models
{
    public partial class SubscriptionMeterUsageSpecSchema
    {
        [JsonProperty("items")]
        public List<SubscriptionMeterUsageItemSchema> Items { get; set; }
    }
}