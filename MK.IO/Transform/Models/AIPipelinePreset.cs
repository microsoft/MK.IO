// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;
using System.Text;

namespace MK.IO.Models
{
    public class AIPipelinePreset : TransformPreset
    {
        /// <summary>
        /// The discriminator for derived types. Must be set to #MediaKind.AIPipelinePreset
        /// </summary>
        /// <value>The discriminator for derived types. Must be set to #MediaKind.AIPipelinePreset</value>
        [JsonProperty("@odata.type")]
        internal override string OdataType => "#MediaKind.AIPipelinePreset";

        /// <summary>
        /// Gets or Sets Pipeline
        /// </summary>
        [JsonProperty(PropertyName = "pipeline")]
        public PipelineArguments Pipeline { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AIPipelinePreset {\n");
            sb.Append("  OdataType: ").Append(OdataType).Append("\n");
            sb.Append("  Pipeline: ").Append(Pipeline).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Get the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

    }
}
