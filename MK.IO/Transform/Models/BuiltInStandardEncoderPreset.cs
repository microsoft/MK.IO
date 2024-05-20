// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;
using System.Text;

namespace MK.IO.Models
{
    public class BuiltInStandardEncoderPreset : TransformPreset
    {

        public BuiltInStandardEncoderPreset(EncoderNamedPreset presetName)
        {
            PresetName = presetName;
        }

        [JsonProperty("@odata.type")]
        internal override string OdataType => "#Microsoft.Media.BuiltInStandardEncoderPreset";

        [JsonProperty("presetName")]
        public EncoderNamedPreset PresetName { get; set; }

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class BuiltInStandardEncoderPreset {\n");
            sb.Append("  OdataType: ").Append(OdataType).Append("\n");
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