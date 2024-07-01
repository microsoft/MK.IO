// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace MK.IO.Models
{
    /// <summary>
    /// Represents a token restriction. Provided token must match these requirements for successful license or key delivery.
    /// </summary>
    public class ContentKeyPolicyTokenRestriction : ContentKeyPolicyRestriction
    {
        public ContentKeyPolicyTokenRestriction(string issuer, string audience, RestrictionTokenType restrictionTokenType, ContentKeyPolicyVerificationKey primaryVerificationKey,  List<ContentKeyPolicyVerificationKey>? alternateVerificationKeys = null, List<ContentKeyPolicyTokenClaim>? requiredClaims = null, string? openIdConnectDiscoveryDocument = null)
        {
            Issuer = issuer;
            Audience = audience;
            RestrictionTokenType = restrictionTokenType;
            PrimaryVerificationKey = primaryVerificationKey;
            AlternateVerificationKeys = alternateVerificationKeys ?? [];
            RequiredClaims = requiredClaims!;
            OpenIdConnectDiscoveryDocument = openIdConnectDiscoveryDocument!;
        }

        [JsonPropertyName("@odata.type")]
        internal override string OdataType => "#Microsoft.Media.ContentKeyPolicyTokenRestriction";

        /// <summary>
        /// A list of alternative verification keys.
        /// </summary>
        /// <value>A list of alternative verification keys.</value>
        public List<ContentKeyPolicyVerificationKey> AlternateVerificationKeys { get; set; }

        /// <summary>
        /// The audience for the token.
        /// </summary>
        /// <value>The audience for the token.</value>
        public string Audience { get; set; }

        /// <summary>
        /// The token issuer.
        /// </summary>
        /// <value>The token issuer.</value>
        public string Issuer { get; set; }

        /// <summary>
        /// The OpenID connect discovery document.
        /// </summary>
        /// <value>The OpenID connect discovery document.</value>
        public string OpenIdConnectDiscoveryDocument { get; set; }

        /// <summary>
        /// The primary verification key.
        /// </summary>
        /// <value>The primary verification key.</value>
        public ContentKeyPolicyVerificationKey PrimaryVerificationKey { get; set; }

        /// <summary>
        /// A list of required token claims.
        /// </summary>
        /// <value>A list of required token claims.</value>
        public List<ContentKeyPolicyTokenClaim> RequiredClaims { get; set; }

        /// <summary>
        /// The type of token.
        /// </summary>
        /// <value>The type of token.</value>
        public RestrictionTokenType RestrictionTokenType { get; set; }
    }
}
