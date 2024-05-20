// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using JsonSubTypes;
using Newtonsoft.Json;

namespace MK.IO.Models
{

    [JsonConverter(typeof(JsonSubtypes), "@odata.type")]
    [JsonSubtypes.KnownSubType(typeof(ContentKeyPolicyRsaTokenKey), "#Microsoft.Media.ContentKeyPolicyRsaTokenKey")]
    [JsonSubtypes.KnownSubType(typeof(ContentKeyPolicySymmetricTokenKey), "#Microsoft.Media.ContentKeyPolicySymmetricTokenKey")]
    [JsonSubtypes.KnownSubType(typeof(ContentKeyPolicyX509CertificateTokenKey), "#Microsoft.Media.ContentKeyPolicyX509CertificateTokenKey")]

    //
    // Summary:
    //     Base class for Content Key Policy verification key. A derived class must be used
    //     to specify the key.
    public abstract class ContentKeyPolicyVerificationKey
    {
        [JsonProperty("@odata.type")]
        internal virtual string OdataType { get; set; }
    }
}
