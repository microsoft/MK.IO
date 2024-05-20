// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace MK.IO.Models
{
    public class ContentKeyPolicyClearKeyConfiguration : ContentKeyPolicyConfiguration
    {
        /// <summary>
        /// Represents a configuration for non-DRM keys.
        /// </summary>
        public ContentKeyPolicyClearKeyConfiguration()
        {
        }

        /// <summary>
        /// The discriminator for derived types.
        /// </summary>
        /// <value>The discriminator for derived types.</value>
        [JsonPropertyName("@odata.type")]
        internal override string OdataType => "#Microsoft.Media.ContentKeyPolicyClearKeyConfiguration";
    }
}