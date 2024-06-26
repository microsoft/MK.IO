// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text;
using Newtonsoft.Json;

namespace MK.IO.Management.Models
{

    /// <summary>
    /// 
    /// </summary>
    public class UserOrganizationsListSchema
    {
        /// <summary>
        /// The kind of record.
        /// </summary>
        /// <value>The kind of record.</value>
        [JsonProperty(PropertyName = "kind")]
        public string Kind { get; set; }

        /// <summary>
        /// List of organizations the user can access or has been invited to.
        /// </summary>
        /// <value>List of organizations the user can access or has been invited to.</value>
        [JsonProperty(PropertyName = "value")]
        public List<UserOrganizationSchema> Value { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class UserOrganizationsListSchema {\n");
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

        public static UserOrganizationsListSchema FromJson(string json)
        {
            return JsonConvert.DeserializeObject<UserOrganizationsListSchema>(json, ConverterLE.Settings) ?? throw new Exception("Error with UserOrganizationsListSchema deserialization");
        }
    }
}
