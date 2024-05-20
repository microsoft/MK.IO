// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace MK.IO.Models
{
    /// <summary>
    /// Represents a ContentKeyPolicyConfiguration that is unavailable in the current API version.
    /// </summary>
    public class ContentKeyPolicyUnknownConfiguration : ContentKeyPolicyConfiguration
    {
        public ContentKeyPolicyUnknownConfiguration()
        {
        }

        [JsonPropertyName("@odata.type")]
        internal override string OdataType => "#Microsoft.Media.ContentKeyPolicyUnknownConfiguration";
    }
}