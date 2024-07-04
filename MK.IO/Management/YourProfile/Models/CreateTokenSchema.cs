// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;

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
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Token expiration date. Maximum one year after creation.
        /// </summary>
        /// <value>Token expiration date. Maximum one year after creation.</value>
        [JsonProperty(PropertyName = "expireDate")]
        public DateTime? ExpireDate { get; set; }

        /// <summary>
        /// ID of the organization that this token allows access to.
        /// </summary>
        /// <value>ID of the organization that this token allows access to.</value>
        [JsonProperty(PropertyName = "organizationId")]
        public Guid? OrganizationId { get; set; }

        /// <summary>
        /// Token permissions. Only needed if the `type` is 'restricted'.
        /// </summary>
        /// <value>Token permissions. Only needed if the `type` is 'restricted'.</value>
        [JsonProperty(PropertyName = "permissions")]
        public Dictionary<string, Object> Permissions { get; set; }

        /// <summary>
        /// Type of token.
        /// </summary>
        /// <value>Type of token.</value>
        [JsonProperty(PropertyName = "type")]
        public UserTokenType Type { get; set; }


        /// <summary>
        /// Get the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, ConverterLE.Settings);
        }
    }
}
