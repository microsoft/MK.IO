// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;

namespace MK.IO.Models
{
    public partial class SubscriptionMeterUsageMetadataSchema
    {
        [JsonProperty("accountId")]
        public Guid AccountId { get; set; }

        [JsonProperty("subscriptionId")]
        public Guid SubscriptionId { get; set; }

        [JsonProperty("start")]
        public DateTime Start { get; set; }

        [JsonProperty("end")]
        public DateTime End { get; set; }
    }
}