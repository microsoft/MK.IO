// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;
using System.Runtime.Serialization;

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

        [JsonProperty("@odata.type")]
        internal override string OdataType => "#Microsoft.Media.ContentKeyPolicyTokenRestriction";

        /// <summary>
        /// A list of alternative verification keys.
        /// </summary>
        /// <value>A list of alternative verification keys.</value>
        [JsonProperty("alternateVerificationKeys")]
        public List<ContentKeyPolicyVerificationKey> AlternateVerificationKeys { get; set; }

        /// <summary>
        /// The audience for the token.
        /// </summary>
        /// <value>The audience for the token.</value>
        [JsonProperty("audience")]
        public string Audience { get; set; }

        /// <summary>
        /// The token issuer.
        /// </summary>
        /// <value>The token issuer.</value>
        [JsonProperty("issuer")]
        public string Issuer { get; set; }

        /// <summary>
        /// The OpenID connect discovery document.
        /// </summary>
        /// <value>The OpenID connect discovery document.</value>
        [DataMember(Name = "openIdConnectDiscoveryDocument", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "openIdConnectDiscoveryDocument")]
        public string OpenIdConnectDiscoveryDocument { get; set; }

        /// <summary>
        /// The primary verification key.
        /// </summary>
        /// <value>The primary verification key.</value>
        [JsonProperty("primaryVerificationKey")]
        public ContentKeyPolicyVerificationKey PrimaryVerificationKey { get; set; }

        /// <summary>
        /// A list of required token claims.
        /// </summary>
        /// <value>A list of required token claims.</value>
        [JsonProperty("requiredClaims")]
        public List<ContentKeyPolicyTokenClaim> RequiredClaims { get; set; }

        /// <summary>
        /// The type of token.
        /// </summary>
        /// <value>The type of token.</value>
        [JsonProperty("restrictionTokenType")]
        public RestrictionTokenType RestrictionTokenType { get; set; }
    }
}
