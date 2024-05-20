// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace MK.IO.Models
{
    /// <summary>
    /// Specifies that the content key ID is in the PlayReady header.
    /// </summary>
    public class ContentKeyPolicyPlayReadyContentEncryptionKeyFromHeader : PlayReadyContentKeyLocation
    {
        public ContentKeyPolicyPlayReadyContentEncryptionKeyFromHeader()
        {
        }

        [JsonPropertyName("@odata.type")]
        internal override string OdataType => "#Microsoft.Media.ContentKeyPolicyPlayReadyContentEncryptionKeyFromHeader";
    }
}
