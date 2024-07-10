// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;

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
        [JsonProperty(PropertyName = "comment")]
        public string Comment { get; set; }

        /// <summary>
        /// Email of the user who sent the invite.
        /// </summary>
        /// <value>Email of the user who sent the invite.</value>
        [JsonProperty(PropertyName = "invitedBy")]
        public string InvitedBy { get; set; }

        /// <summary>
        /// State of the invite.
        /// </summary>
        /// <value>State of the invite.</value>
        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }
    }
}
