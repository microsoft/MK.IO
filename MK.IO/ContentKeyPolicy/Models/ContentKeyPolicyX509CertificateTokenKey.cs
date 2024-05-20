// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace MK.IO.Models
{
    /// <summary>
    /// Specifies a certificate for token validation.
    /// </summary>

    public class ContentKeyPolicyX509CertificateTokenKey : ContentKeyPolicyVerificationKey
    {
        public ContentKeyPolicyX509CertificateTokenKey(byte[] rawBody)
        {
            RawBody = rawBody;
        }

        [JsonPropertyName("@odata.type")]
        internal override string OdataType => "#Microsoft.Media.ContentKeyPolicyX509CertificateTokenKey";

        /// <summary>
        /// The raw data field of a certificate in PKCS 12 format (X509Certificate2 in .NET)
        /// </summary>
        /// <value>The raw data field of a certificate in PKCS 12 format (X509Certificate2 in .NET)</value>
        public byte[] RawBody { get; set; }
    }
}
