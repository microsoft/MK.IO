// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;

namespace MK.IO.Management.Models
{

    /// <summary>
    /// 
    /// </summary>
    public class UserOrganizationSpecSchema
    {
        /// <summary>
        /// Gets or Sets Invite
        /// </summary>
        [JsonProperty(PropertyName = "invite")]
        public UserOrganizationPendingInviteSchema Invite { get; set; }
    }
}
