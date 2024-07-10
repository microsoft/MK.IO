// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json;

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
        public string Description { get; set; }

        /// <summary>
        /// Date token expires.
        /// </summary>
        /// <value>Date token expires.</value>
        public DateTime? Expires { get; set; }

        /// <summary>
        /// Date token was issued.
        /// </summary>
        /// <value>Date token was issued.</value>
        public DateTime? Issued { get; set; }

        /// <summary>
        /// Date token was last used on the MK.IO api.
        /// </summary>
        /// <value>Date token was last used on the MK.IO api.</value>
        public DateTime? LastUsed { get; set; }

        /// <summary>
        /// ID of the organization that this token allows access to.
        /// </summary>
        /// <value>ID of the organization that this token allows access to.</value>
        public Guid? OrganizationId { get; set; }

        /// <summary>
        /// The RBAC capabilities assigned to the token when type is 'restricted'
        /// </summary>
        /// <value>The RBAC capabilities assigned to the token when type is 'restricted'</value>
        public Dictionary<string, Object> Permissions { get; set; }

        /// <summary>
        /// Date token was revoked, or null if not revoked.
        /// </summary>
        /// <value>Date token was revoked, or null if not revoked.</value>
        public DateTime? Revoked { get; set; }

        /// <summary>
        /// Email of user who revoked this token.
        /// </summary>
        /// <value>Email of user who revoked this token.</value>
        public string RevokedBy { get; set; }

        /// <summary>
        /// Email of user the token was issued for.
        /// </summary>
        /// <value>Email of user the token was issued for.</value>
        public string User { get; set; }
    }
}
