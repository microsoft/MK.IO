// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MK.IO.Management.Models
{

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class UserMetadata
    {
        /// <summary>
        /// The unique identifier of the user.
        /// </summary>
        /// <value>The unique identifier of the user.</value>
        [JsonProperty("id")]
        public Guid? Id { get; set; }

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class UserMetadata {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
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
    }
}
