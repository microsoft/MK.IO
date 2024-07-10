// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json;

namespace MK.IO.Management.Models
{

    /// <summary>
    /// 
    /// </summary>
    public class UserOrganizationSchema
    {
        /// <summary>
        /// Gets or Sets Metadata
        /// </summary>
        public UserOrganizationMetadataSchema Metadata { get; set; }

        /// <summary>
        /// Gets or Sets Spec
        /// </summary>
        public UserOrganizationSpecSchema Spec { get; set; }
    }
}
