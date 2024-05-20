// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace MK.IO.Models
{

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class TrackPropertyCompareOperation
    {
        /// <summary>
        /// The track property comparison operation
        /// </summary>
        /// <value>The track property comparison operation</value>
        [DataMember(Name = "Equal", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Equal")]
        public string Equal { get; set; }

        /// <summary>
        /// The track property comparison operation
        /// </summary>
        /// <value>The track property comparison operation</value>
        [DataMember(Name = "Unknown", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Unknown")]
        public string Unknown { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TrackPropertyCompareOperation {\n");
            sb.Append("  Equal: ").Append(Equal).Append("\n");
            sb.Append("  Unknown: ").Append(Unknown).Append("\n");
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
