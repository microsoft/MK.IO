// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text;
using System.Text.Json;

namespace MK.IO.Management.Models
{

    /// <summary>
    /// 
    /// </summary>
    public class UserTokenWithSecretMetadataSchema
    {
        /// <summary>
        /// ID of token.
        /// </summary>
        /// <value>ID of token.</value>
        public Guid? Id { get; set; }

        /// <summary>
        /// Token type.
        /// </summary>
        /// <value>Token type.</value>
        public UserTokenType Type { get; set; }

        /// <summary>
        /// JWT.
        /// </summary>
        /// <value>Token JWT.</value>
        public string JWT { get; set; }
    }
}
