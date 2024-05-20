// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.



using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MK.IO.Models
{

    /// <summary>
    /// 
    /// </summary>

    public class TransformProperties
    {
        /// <summary>
        /// The creation date and time of the Transform. Set by the system.
        /// </summary>
        /// <value>The creation date and time of the Transform. Set by the system.</value>
        [JsonInclude]
        public DateTime? Created { get; private set; }

        /// <summary>
        /// The description of the Transform.
        /// </summary>
        /// <value>The description of the Transform.</value>
        public string Description { get; set; }

        /// <summary>
        /// The last modified date and time of the Transform. Set by the system.
        /// </summary>
        /// <value>The last modified date and time of the Transform. Set by the system.</value>
        [JsonInclude]
        public DateTime? LastModified { get; private set; }

        /// <summary>
        /// An array of TransformOutputs that the Transform should generate. Currently limited to one.
        /// </summary>
        /// <value>An array of TransformOutputs that the Transform should generate. Currently limited to one.</value>
        public List<TransformOutput> Outputs { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TransformProperties {\n");
            sb.Append("  Created: ").Append(Created).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  LastModified: ").Append(LastModified).Append("\n");
            sb.Append("  Outputs: ").Append(Outputs).Append("\n");
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
