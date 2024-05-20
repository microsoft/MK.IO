// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace MK.IO.Models
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "@odata.type")]
    [JsonDerivedType(typeof(ContentKeyPolicyPlayReadyConfiguration), typeDiscriminator: "#Microsoft.Media.ContentKeyPolicyPlayReadyConfiguration")]
    [JsonDerivedType(typeof(ContentKeyPolicyWidevineConfiguration), typeDiscriminator: "#Microsoft.Media.ContentKeyPolicyWidevineConfiguration")]
    [JsonDerivedType(typeof(ContentKeyPolicyFairPlayConfiguration), typeDiscriminator: "#Microsoft.Media.ContentKeyPolicyFairPlayConfiguration")]
    [JsonDerivedType(typeof(ContentKeyPolicyClearKeyConfiguration), typeDiscriminator: "#Microsoft.Media.ContentKeyPolicyClearKeyConfiguration")]
    [JsonDerivedType(typeof(ContentKeyPolicyUnknownConfiguration), typeDiscriminator: "#Microsoft.Media.ContentKeyPolicyUnknownConfiguration")]

    //
    // Summary:
    //     Base class for Content Key Policy configuration. A derived class must be used
    //     to create a configuration.
    public class ContentKeyPolicyConfiguration
    {
        [JsonPropertyName("@odata.type")]
        internal virtual string OdataType { get; set; }
    }
}