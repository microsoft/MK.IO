// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace MK.IO.Models
{
    /// <summary>
    /// Specifies a configuration for PlayReady licenses.
    /// </summary>
    public class ContentKeyPolicyPlayReadyConfiguration : ContentKeyPolicyConfiguration
    {
        public ContentKeyPolicyPlayReadyConfiguration(List<ContentKeyPolicyPlayReadyLicense> licenses)
        {
            Licenses = licenses;
        }

        [JsonPropertyName("@odata.type")]
        internal override string OdataType => "#Microsoft.Media.ContentKeyPolicyPlayReadyConfiguration";

        /// <summary>
        /// The PlayReady licenses.
        /// </summary>
        /// <value>The PlayReady licenses.</value>
        public List<ContentKeyPolicyPlayReadyLicense> Licenses { get; set; }

        /// <summary>
        /// The custom response data.
        /// </summary>
        /// <value>The custom response data.</value>
        public string ResponseCustomData { get; set; }
    }
}