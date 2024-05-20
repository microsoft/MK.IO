// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

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

        [JsonPropertyName("@odata.type")]
        internal override string OdataType => "#Microsoft.Media.ContentKeyPolicyWidevineConfiguration";

        /// <summary>
        /// The Widevine template.
        /// </summary>
        /// <value>The Widevine template.</value>
        public string WidevineTemplate { get; set; }
    }
}