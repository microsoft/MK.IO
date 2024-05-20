// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace MK.IO.Models
{
    public class SubscriptionSchema
    {
        public Guid CustomerId { get; set; }

        [JsonInclude]
        public Guid CreatedById { get; private set; }

        public Guid LocationId { get; set; }

        public string? AzureSubscriptionName { get; set; }

        public string? Name { get; set; }

        public bool IsActive { get; set; }

        public Guid ProjectSubscriptionId { get; set; }

        public Guid ProductPublicationId { get; set; }

        public string? AzureSubscriptionStatus { get; set; }

        public Guid AzureSubscriptionId { get; set; }

        public string? AzureSubscriptionOfferId { get; set; }

        public string? AzureSubscriptionPlanId { get; set; }
    }
}