// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;

namespace MK.IO.Management.Models
{

    /// <summary>
    /// 
    /// </summary>
    public class UserTokenSpecSchema
    {
        /// <summary>
        /// Description of the token. Max 128 characters.
        /// </summary>
        /// <value>Description of the token. Max 128 characters.</value>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Date token expires.
        /// </summary>
        /// <value>Date token expires.</value>
        [JsonProperty(PropertyName = "expires")]
        public DateTime? Expires { get; set; }

        /// <summary>
        /// Date token was issued.
        /// </summary>
        /// <value>Date token was issued.</value>
        [JsonProperty(PropertyName = "issued")]
        public DateTime? Issued { get; set; }

        /// <summary>
        /// Date token was last used on the MK.IO api.
        /// </summary>
        /// <value>Date token was last used on the MK.IO api.</value>
        [JsonProperty(PropertyName = "lastUsed")]
        public DateTime? LastUsed { get; set; }

        /// <summary>
        /// ID of the organization that this token allows access to.
        /// </summary>
        /// <value>ID of the organization that this token allows access to.</value>
        [JsonProperty(PropertyName = "organizationId")]
        public Guid? OrganizationId { get; set; }

        /// <summary>
        /// The RBAC capabilities assigned to the token when type is 'restricted'
        /// </summary>
        /// <value>The RBAC capabilities assigned to the token when type is 'restricted'</value>
        [JsonProperty(PropertyName = "permissions")]
        public Dictionary<string, Object> Permissions { get; set; }

        /// <summary>
        /// Date token was revoked, or null if not revoked.
        /// </summary>
        /// <value>Date token was revoked, or null if not revoked.</value>
        [JsonProperty(PropertyName = "revoked")]
        public DateTime? Revoked { get; set; }

        /// <summary>
        /// Email of user who revoked this token.
        /// </summary>
        /// <value>Email of user who revoked this token.</value>
        [JsonProperty(PropertyName = "revokedBy")]
        public string RevokedBy { get; set; }

        /// <summary>
        /// Email of user the token was issued for.
        /// </summary>
        /// <value>Email of user the token was issued for.</value>
        [JsonProperty(PropertyName = "user")]
        public string User { get; set; }
    }
}
