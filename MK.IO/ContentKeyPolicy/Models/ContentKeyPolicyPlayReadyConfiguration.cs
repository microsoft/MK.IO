// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;

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

        [JsonProperty("@odata.type")]
        internal override string OdataType => "#Microsoft.Media.ContentKeyPolicyPlayReadyConfiguration";

        /// <summary>
        /// The PlayReady licenses.
        /// </summary>
        /// <value>The PlayReady licenses.</value>
        [JsonProperty("licenses")]
        public List<ContentKeyPolicyPlayReadyLicense> Licenses { get; set; }

        /// <summary>
        /// The custom response data.
        /// </summary>
        /// <value>The custom response data.</value>
        [JsonProperty(PropertyName = "responseCustomData")]
        public string ResponseCustomData { get; set; }
    }
}