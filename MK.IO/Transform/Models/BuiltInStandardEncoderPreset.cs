// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MK.IO.Models
{
    public class BuiltInStandardEncoderPreset : TransformPreset
    {
        /// <summary>
        /// Constructor for BuiltInStandardEncoderPreset
        /// </summary>
        /// <param name="presetName"></param>
        public BuiltInStandardEncoderPreset(EncoderNamedPreset presetName)
        {
            PresetName = presetName;
        }

        [JsonPropertyName("@odata.type")]
        internal override string OdataType => "#Microsoft.Media.BuiltInStandardEncoderPreset";

        /// <summary>
        /// The built-in preset to be used for encoding videos.
        /// </summary>
        /// <value>The built-in preset to be used for encoding videos.
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
            return JsonSerializer.Serialize(this, ConverterLE.Settings);
        }
    }
}