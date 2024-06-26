// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;

namespace MK.IO.Management.Models
{

    /// <summary>
    /// 
    /// </summary>
    public class UserOrganizationMetadataSchema
    {
        /// <summary>
        /// ID of the organization.
        /// </summary>
        /// <value>ID of the organization.</value>
        [JsonProperty(PropertyName = "id")]
        public Guid? Id { get; set; }

        /// <summary>
        /// Name of the organization.
        /// </summary>
        /// <value>Name of the organization.</value>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}
