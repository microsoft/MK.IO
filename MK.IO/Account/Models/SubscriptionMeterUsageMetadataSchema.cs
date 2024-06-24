// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace MK.IO.Models
{
    public partial class SubscriptionMeterUsageMetadataSchema
    {
        public Guid AccountId { get; set; }

        public Guid SubscriptionId { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }
    }
}