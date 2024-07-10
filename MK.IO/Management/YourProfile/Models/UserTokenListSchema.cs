// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text;
using Newtonsoft.Json;

namespace MK.IO.Management.Models
{

    /// <summary>
    /// 
    /// </summary>
    public class UserTokenListSchema
    {
        /// <summary>
        /// The kind of record.
        /// </summary>
        /// <value>The kind of record.</value>
        [JsonProperty(PropertyName = "kind")]
        public string Kind { get; set; }

        /// <summary>
        /// Token list.
        /// </summary>
        /// <value>Token list.</value>
        [JsonProperty(PropertyName = "value")]
        public List<UserTokenSchema> Value { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class UserTokenListSchema {\n");
            sb.Append("  Kind: ").Append(Kind).Append("\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Get the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, ConverterLE.Settings);
        }

        public static UserTokenListSchema FromJson(string json)
        {
            return JsonConvert.DeserializeObject<UserTokenListSchema>(json, ConverterLE.Settings) ?? throw new Exception("Error with UserTokenListSchema deserialization");
        }

    }
}
