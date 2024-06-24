// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace MK.IO.Models
{
    public class SubscriptionMeterUsageItemSchema
    {
        public SubscriptionMeterUsageItemSpecSchema Spec { get; set; }
    }
    public partial class SubscriptionMeterUsageItemSpecSchema
    {
        public Guid MeterUnitId { get; set; }

        public string MeterUnitName { get; set; }

        public string MeterName { get; set; }

        public double Total { get; set; }
    }
}