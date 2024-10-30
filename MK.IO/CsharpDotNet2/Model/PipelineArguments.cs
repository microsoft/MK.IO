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
    public class PipelineArguments
    {
        /// <summary>
        /// Arguments to each operation in the AI pipeline
        /// </summary>
        /// <value>Arguments to each operation in the AI pipeline</value>
        [DataMember(Name = "arguments", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "arguments")]
        public Dictionary<string, Object> Arguments { get; set; }

        /// <summary>
        /// Not currently supported. The name of the AI pipeline the Transform will execute.
        /// </summary>
        /// <value>Not currently supported. The name of the AI pipeline the Transform will execute.</value>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PipelineArguments {\n");
            sb.Append("  Arguments: ").Append(Arguments).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
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
