// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json;

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
        public Guid? Id { get; set; }

        /// <summary>
        /// Token type.
        /// </summary>
        /// <value>Token type.</value>
        public UserTokenType Type { get; set; }
    }
}
