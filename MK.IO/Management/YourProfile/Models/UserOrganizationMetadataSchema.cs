// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json;

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
        public Guid? Id { get; set; }

        /// <summary>
        /// Name of the organization.
        /// </summary>
        /// <value>Name of the organization.</value>
        public string Name { get; set; }
    }
}
