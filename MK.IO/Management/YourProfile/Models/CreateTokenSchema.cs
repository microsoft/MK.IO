// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json;

namespace MK.IO.Management.Models
{

    /// <summary>
    /// 
    /// </summary>
    public class CreateTokenSchema
    {
        /// <summary>
        /// Description of the token. Max 128 characters.
        /// </summary>
        /// <value>Description of the token. Max 128 characters.</value>
        public string Description { get; set; }

        /// <summary>
        /// Token expiration date. Maximum one year after creation.
        /// </summary>
        /// <value>Token expiration date. Maximum one year after creation.</value>
        public DateTime? ExpireDate { get; set; }

        /// <summary>
        /// ID of the organization that this token allows access to.
        /// </summary>
        /// <value>ID of the organization that this token allows access to.</value>
        public Guid? OrganizationId { get; set; }

        /// <summary>
        /// Token permissions. Only needed if the `type` is 'restricted'.
        /// </summary>
        /// <value>Token permissions. Only needed if the `type` is 'restricted'.</value>
        public Dictionary<string, Object> Permissions { get; set; }

        /// <summary>
        /// Type of token.
        /// </summary>
        /// <value>Type of token.</value>
        public UserTokenType Type { get; set; }


        /// <summary>
        /// Get the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonSerializer.Serialize(this, ConverterLE.Settings);
        }
    }
}
