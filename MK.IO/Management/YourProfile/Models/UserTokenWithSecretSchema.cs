// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;

namespace MK.IO.Management.Models
{

    /// <summary>
    /// 
    /// </summary>
    public class UserTokenWithSecretSchema
    {
        /// <summary>
        /// Gets or Sets Metadata
        /// </summary>
        [JsonProperty(PropertyName = "metadata")]
        public UserTokenWithSecretMetadataSchema Metadata { get; set; }

        /// <summary>
        /// Gets or Sets Spec
        /// </summary>
        [JsonProperty(PropertyName = "spec")]
        public UserTokenSpecSchema Spec { get; set; }
    }
}
