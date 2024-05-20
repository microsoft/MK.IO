// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace MK.IO.Models
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "@odata.type")]
    [JsonDerivedType(typeof(ContentKeyPolicyRsaTokenKey), typeDiscriminator: "#Microsoft.Media.ContentKeyPolicyRsaTokenKey")]
    [JsonDerivedType(typeof(ContentKeyPolicySymmetricTokenKey), typeDiscriminator: "#Microsoft.Media.ContentKeyPolicySymmetricTokenKey")]
    [JsonDerivedType(typeof(ContentKeyPolicyX509CertificateTokenKey), typeDiscriminator: "#Microsoft.Media.ContentKeyPolicyX509CertificateTokenKey")]

    //
    // Summary:
    //     Base class for Content Key Policy verification key. A derived class must be used
    //     to specify the key.
    public abstract class ContentKeyPolicyVerificationKey
    {
        [JsonPropertyName("@odata.type")]
        internal virtual string OdataType { get; set; }
    }
}
