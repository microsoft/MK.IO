// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;

namespace MK.IO.Management.Models
{

    /// <summary>
    /// 
    /// </summary>
    public class UserTokenSchema
    {
        /// <summary>
        /// Gets or Sets Metadata
        /// </summary>
        [JsonProperty(PropertyName = "metadata")]
        public UserTokenMetadataSchema Metadata { get; set; }

        /// <summary>
        /// Gets or Sets Spec
        /// </summary>
        [JsonProperty(PropertyName = "spec")]
        public UserTokenSpecSchema Spec { get; set; }

        public static UserTokenSchema FromJson(string json)
        {
            return JsonConvert.DeserializeObject<UserTokenSchema>(json, ConverterLE.Settings) ?? throw new Exception("Error with UserTokenSchema deserialization");
        }
    }
}
