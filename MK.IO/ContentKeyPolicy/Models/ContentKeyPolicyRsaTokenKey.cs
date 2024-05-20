// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace MK.IO.Models
{
    /// <summary>
    /// Specifies a RSA key for token validation
    /// </summary>

    public class ContentKeyPolicyRsaTokenKey : ContentKeyPolicyVerificationKey
    {
        public ContentKeyPolicyRsaTokenKey(byte[] exponent, byte[] modulus)
        {
            Exponent = exponent;
            Modulus = modulus;
        }

        [JsonPropertyName("@odata.type")]
        internal override string OdataType => "#Microsoft.Media.ContentKeyPolicyRsaTokenKey";

        /// <summary>
        /// The RSA Parameter exponent
        /// </summary>
        /// <value>The RSA Parameter exponent</value>
        public byte[] Exponent { get; set; }

        /// <summary>
        /// The RSA Parameter modulus
        /// </summary>
        /// <value>The RSA Parameter modulus</value>
        public byte[] Modulus { get; set; }
    }
}
