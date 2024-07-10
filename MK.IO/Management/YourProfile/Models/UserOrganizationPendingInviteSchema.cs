// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json;

namespace MK.IO.Management.Models
{

    /// <summary>
    /// 
    /// </summary>
    public class UserOrganizationPendingInviteSchema
    {
        /// <summary>
        /// Comment from the inviter.
        /// </summary>
        /// <value>Comment from the inviter.</value>
        public string Comment { get; set; }

        /// <summary>
        /// Email of the user who sent the invite.
        /// </summary>
        /// <value>Email of the user who sent the invite.</value>
        public string InvitedBy { get; set; }

        /// <summary>
        /// State of the invite.
        /// </summary>
        /// <value>State of the invite.</value>
        public string State { get; set; }
    }
}
