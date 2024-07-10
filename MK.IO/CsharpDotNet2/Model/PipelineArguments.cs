// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json;
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
        /// Not currently supported. Arguments to each operation in the AI pipeline
        /// </summary>
        /// <value>Not currently supported. Arguments to each operation in the AI pipeline</value>
        public Dictionary<string, Object> Arguments { get; set; }

        /// <summary>
        /// Not currently supported. The name of the AI pipeline the Transform will execute.
        /// </summary>
        /// <value>Not currently supported. The name of the AI pipeline the Transform will execute.</value>
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
            return JsonSerializer.Serialize(this, ConverterLE.Settings);
        }
    }
}
