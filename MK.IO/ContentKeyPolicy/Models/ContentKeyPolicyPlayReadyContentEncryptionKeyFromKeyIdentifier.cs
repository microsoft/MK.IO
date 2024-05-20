// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

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

        [JsonPropertyName("@odata.type")]
        internal override string OdataType => "#Microsoft.Media.ContentKeyPolicyPlayReadyContentEncryptionKeyFromKeyIdentifier";

        /// <summary>
        /// The content key ID.
        /// </summary>
        /// <value>The content key ID.</value>
        public Guid? KeyId { get; set; }
    }
}
