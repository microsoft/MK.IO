// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;

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

        [JsonProperty("@odata.type")]
        internal override string OdataType => "#Microsoft.Media.ContentKeyPolicyUnknownConfiguration";
    }
}