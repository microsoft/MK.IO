// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;

namespace MK.IO.Models
{
    /// <summary>
    /// Specifies a configuration for Widevine licenses.
    /// </summary>
    public class ContentKeyPolicyWidevineConfiguration : ContentKeyPolicyConfiguration
    {
        public ContentKeyPolicyWidevineConfiguration(string widevineTemplate)
        {
            WidevineTemplate = widevineTemplate;
        }

        [JsonProperty("@odata.type")]
        internal override string OdataType => "#Microsoft.Media.ContentKeyPolicyWidevineConfiguration";

        /// <summary>
        /// The Widevine template.
        /// </summary>
        /// <value>The Widevine template.</value>
        [JsonProperty("widevineTemplate")]
        public string WidevineTemplate { get; set; }
    }
}