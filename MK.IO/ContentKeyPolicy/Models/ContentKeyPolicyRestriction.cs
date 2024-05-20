// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace MK.IO.Models
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "@odata.type")]
    [JsonDerivedType(typeof(ContentKeyPolicyTokenRestriction), typeDiscriminator: "#Microsoft.Media.ContentKeyPolicyTokenRestriction")]
    [JsonDerivedType(typeof(ContentKeyPolicyOpenRestriction), typeDiscriminator: "#Microsoft.Media.ContentKeyPolicyOpenRestriction")]
    [JsonDerivedType(typeof(ContentKeyPolicyUnknownRestriction), typeDiscriminator: "#Microsoft.Media.ContentKeyPolicyUnknownRestriction")]

    //
    // Summary:
    //     Base class for Content Key Policy restrictions. A derived class must be used
    //     to create a restriction.
    public class ContentKeyPolicyRestriction
    {

        [JsonPropertyName("@odata.type")]
        internal virtual string OdataType { get; set; }
    }
}
