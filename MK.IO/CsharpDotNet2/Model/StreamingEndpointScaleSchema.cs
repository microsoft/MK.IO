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
    public class StreamingEndpointScaleSchema
    {
        /// <summary>
        /// The scale unit count for this streaming endpoint.
        /// </summary>
        /// <value>The scale unit count for this streaming endpoint.</value>
        [DataMember(Name = "scaleUnit", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "scaleUnit")]
        public int? ScaleUnit { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class StreamingEndpointScaleSchema {\n");
            sb.Append("  ScaleUnit: ").Append(ScaleUnit).Append("\n");
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
