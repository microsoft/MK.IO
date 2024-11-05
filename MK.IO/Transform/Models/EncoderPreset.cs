// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace MK.IO.Models
{
    public class EncoderPreset : TransformPreset
    {
        /// <summary>
        /// Constructor for EncoderPreset
        /// </summary>
        /// <param name="presetName"></param>
        public EncoderPreset(string presetName, Dictionary<string, string> config)
        {
            PresetName = presetName;
            Config = config;
        }

        [JsonProperty("@odata.type")]
        internal override string OdataType => "#MediaKind.EncoderPreset";

        /// <summary>
        /// The configuration for the custom preset.
        /// </summary>
        /// <value>The configuration for the custom preset.</value>
        [DataMember(Name = "config", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "config")]
        public Dictionary<string, string> Config { get; set; }

        /// <summary>
        /// Name of this preset.
        /// </summary>
        /// <value>Name of this preset.</value>
        [DataMember(Name = "presetName", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "presetName")]
        public string PresetName { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class EncoderPreset {\n");
            sb.Append("  OdataType: ").Append(OdataType).Append("\n");
            sb.Append("  Config: ").Append(Config).Append("\n");
            sb.Append("  PresetName: ").Append(PresetName).Append("\n");
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