// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;

namespace MK.IO.Models
{
    public class SubscriptionMeterUsageItemSchema
    {
        [JsonProperty("spec")]
        public SubscriptionMeterUsageItemSpecSchema Spec { get; set; }
    }
    public partial class SubscriptionMeterUsageItemSpecSchema
    {
        [JsonProperty("meterUnitId")]
        public Guid MeterUnitId { get; set; }

        [JsonProperty("meterUnitName")]
        public string MeterUnitName { get; set; }

        [JsonProperty("meterName")]
        public string MeterName { get; set; }

        [JsonProperty("total")]
        public double Total { get; set; }
    }
}