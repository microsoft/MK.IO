// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;

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
        [JsonProperty(PropertyName = "metadata")]
        public UserOrganizationMetadataSchema Metadata { get; set; }

        /// <summary>
        /// Gets or Sets Spec
        /// </summary>
        [JsonProperty(PropertyName = "spec")]
        public UserOrganizationSpecSchema Spec { get; set; }
    }
}
