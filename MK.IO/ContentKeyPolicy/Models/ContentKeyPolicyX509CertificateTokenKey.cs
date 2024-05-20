// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace MK.IO.Models
{

    /// <summary>
    /// Specifies a certificate for token validation.
    /// </summary>
    [DataContract]
    public class ContentKeyPolicyX509CertificateTokenKey : ContentKeyPolicyVerificationKey
    {
        public ContentKeyPolicyX509CertificateTokenKey(byte[] rawBody)
        {
            RawBody = rawBody;
        }

        [JsonProperty("@odata.type")]
        internal override string OdataType => "#Microsoft.Media.ContentKeyPolicyX509CertificateTokenKey";

        /// <summary>
        /// The raw data field of a certificate in PKCS 12 format (X509Certificate2 in .NET)
        /// </summary>
        /// <value>The raw data field of a certificate in PKCS 12 format (X509Certificate2 in .NET)</value>
        [DataMember(Name = "rawBody", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "rawBody")]
        public byte[] RawBody { get; set; }
    }
}
