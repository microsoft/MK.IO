// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text;
using System.Text.Json;



namespace MK.IO.Models
{

    /// <summary>
    /// Represents a token claim.
    /// </summary>

    public class ContentKeyPolicyTokenClaim
    {
        /// <summary>
        /// The claim type for the ContentKeyIdentifierClaim.
        /// </summary>
        public static readonly string ContentKeyIdentifierClaimType = "urn:microsoft:azure:mediaservices:contentkeyidentifier";

        /// <summary>
        /// This claim requires that the value of the claim in the token must match the key identifier of the key being requested by the client.
        /// Adding this claim means that the token issued to the client authorizes access to the content key identifier listed in the token.
        /// </summary>
        public static readonly ContentKeyPolicyTokenClaim ContentKeyIdentifierClaim = new ()
        {
            ClaimType = ContentKeyIdentifierClaimType
        };

        /// <summary>
        /// Token claim type.
        /// </summary>
        /// <value>Token claim type.</value>
        public string ClaimType { get; set; }

        /// <summary>
        /// Token claim value.
        /// </summary>
        /// <value>Token claim value.</value>
        public string ClaimValue { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ContentKeyPolicyTokenClaim {\n");
            sb.Append("  ClaimType: ").Append(ClaimType).Append("\n");
            sb.Append("  ClaimValue: ").Append(ClaimValue).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Get the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonSerializer.Serialize(this, ConverterLE.Settings);
        }

    }
}
