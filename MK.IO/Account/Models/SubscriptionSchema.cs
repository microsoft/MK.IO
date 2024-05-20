// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;

namespace MK.IO.Models
{
    public class SubscriptionSchema
    {
        [JsonProperty("customerId")]
        public Guid CustomerId { get; set; }

        [JsonProperty("createdById")]
        public Guid CreatedById { get; private set; }

        [JsonProperty("locationId")]
        public Guid LocationId { get; set; }

        [JsonProperty("azureSubscriptionName")]
        public string? AzureSubscriptionName { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("isActive")]
        public bool IsActive { get; set; }

        [JsonProperty("projectSubscriptionId")]
        public Guid ProjectSubscriptionId { get; set; }

        [JsonProperty("productPublicationId")]
        public Guid ProductPublicationId { get; set; }

        [JsonProperty("azureSubscriptionStatus")]
        public string? AzureSubscriptionStatus { get; set; }

        [JsonProperty("azureSubscriptionId")]
        public Guid AzureSubscriptionId { get; set; }

        [JsonProperty("azureSubscriptionOfferId")]
        public string? AzureSubscriptionOfferId { get; set; }

        [JsonProperty("azureSubscriptionPlanId")]
        public string? AzureSubscriptionPlanId { get; set; }
    }
}