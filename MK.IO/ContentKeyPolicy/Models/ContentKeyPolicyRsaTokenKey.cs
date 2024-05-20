// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace MK.IO.Models
{

    /// <summary>
    /// Specifies a RSA key for token validation
    /// </summary>
    [DataContract]
    public class ContentKeyPolicyRsaTokenKey : ContentKeyPolicyVerificationKey
    {
        public ContentKeyPolicyRsaTokenKey(byte[] exponent, byte[] modulus)
        {
            Exponent = exponent;
            Modulus = modulus;
        }

        [JsonProperty("@odata.type")]
        internal override string OdataType => "#Microsoft.Media.ContentKeyPolicyRsaTokenKey";

        /// <summary>
        /// The RSA Parameter exponent
        /// </summary>
        /// <value>The RSA Parameter exponent</value>
        [DataMember(Name = "exponent", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "exponent")]
        public byte[] Exponent { get; set; }

        /// <summary>
        /// The RSA Parameter modulus
        /// </summary>
        /// <value>The RSA Parameter modulus</value>
        [DataMember(Name = "modulus", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "modulus")]
        public byte[] Modulus { get; set; }
    }
}
