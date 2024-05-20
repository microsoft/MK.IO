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

    public class AudioAnalyzerPreset : TransformPreset
    {
        /// <summary>
        /// The discriminator for derived types.
        /// </summary>
        /// <value>The discriminator for derived types.</value>
        [JsonPropertyName("@odata.type")]
        internal override string OdataType => "#Microsoft.Media.AudioAnalyzerPreset";

        /// <summary>
        /// The language for the audio payload in the input using the BCP-47 format of 'language tag-region' (e.g: 'en-US')
        /// </summary>
        /// <value>The language for the audio payload in the input using the BCP-47 format of 'language tag-region' (e.g: 'en-US')</value>
        public string AudioLanguage { get; set; }

        /// <summary>
        /// Dictionary containing key value pairs for parameters not exposed in the preset itself
        /// </summary>
        /// <value>Dictionary containing key value pairs for parameters not exposed in the preset itself</value>
        public Dictionary<string, Object> ExperimentalOptions { get; set; }

        /// <summary>
        /// Determines the set of audio analysis operations to be performed. If unspecified, the Standard AudioAnalysisMode would be chosen.
        /// </summary>
        /// <value>Determines the set of audio analysis operations to be performed. If unspecified, the Standard AudioAnalysisMode would be chosen.</value>
        public AudioAnalysisMode Mode { get; set; }

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AudioAnalyzerPreset {\n");
            sb.Append("  OdataType: ").Append(OdataType).Append("\n");
            sb.Append("  AudioLanguage: ").Append(AudioLanguage).Append("\n");
            sb.Append("  ExperimentalOptions: ").Append(ExperimentalOptions).Append("\n");
            sb.Append("  Mode: ").Append(Mode).Append("\n");
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
