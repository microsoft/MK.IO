// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text;
using Newtonsoft.Json;

namespace MK.IO.Management.Models
{

    /// <summary>
    /// 
    /// </summary>
    public class UserTokenMetadataSchema
    {
        /// <summary>
        /// ID of token.
        /// </summary>
        /// <value>ID of token.</value>
        [JsonProperty(PropertyName = "id")]
        public Guid? Id { get; set; }

        /// <summary>
        /// Token type.
        /// </summary>
        /// <value>Token type.</value>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// JWT.
        /// </summary>
        /// <value>Token JWT.</value>
        [JsonProperty(PropertyName = "JWT")]
        public string JWT { get; set; }
    }
}
