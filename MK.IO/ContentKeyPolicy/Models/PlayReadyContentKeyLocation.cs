// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace MK.IO.Models
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "@odata.type")]
    [JsonDerivedType(typeof(ContentKeyPolicyPlayReadyContentEncryptionKeyFromHeader), typeDiscriminator: "#Microsoft.Media.ContentKeyPolicyPlayReadyContentEncryptionKeyFromHeader")]
    [JsonDerivedType(typeof(ContentKeyPolicyPlayReadyContentEncryptionKeyFromKeyIdentifier), typeDiscriminator: "#Microsoft.Media.ContentKeyPolicyPlayReadyContentEncryptionKeyFromKeyIdentifier")]
    
    //
    // Summary:
    //     Base class for PlayReady content key location. A derived class must be used
    //     to specify a location.
    public class PlayReadyContentKeyLocation
    {
        [JsonPropertyName("@odata.type")]
        internal virtual string OdataType { get; set; }
    }
}
