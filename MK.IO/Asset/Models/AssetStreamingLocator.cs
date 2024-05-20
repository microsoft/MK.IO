// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace MK.IO.Models
{
    public class AssetStreamingLocator
    {
        public string Name { get; set; }

        public string AssetName { get; set; }

        public Guid? StreamingLocatorId { get; set; }

        public string? StreamingPolicyName { get; set; }

        public string? DefaultContentKeyPolicyName { get; set; }

        [JsonInclude]
        public DateTime? Created { get; private set; }

        public DateTime? EndTime { get; set; }
    }
}