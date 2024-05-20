// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;

namespace MK.IO.Models
{
    /// <summary>
    /// Specifies that the content key ID is specified in the PlayReady configuration.
    /// </summary>
    public class ContentKeyPolicyPlayReadyContentEncryptionKeyFromKeyIdentifier : PlayReadyContentKeyLocation
    {
        public ContentKeyPolicyPlayReadyContentEncryptionKeyFromKeyIdentifier()
        {
        }

        [JsonProperty("@odata.type")]
        internal override string OdataType => "#Microsoft.Media.ContentKeyPolicyPlayReadyContentEncryptionKeyFromKeyIdentifier";

        /// <summary>
        /// The content key ID.
        /// </summary>
        /// <value>The content key ID.</value>
        [JsonProperty(PropertyName = "keyId")]
        public Guid? KeyId { get; set; }
    }
}
