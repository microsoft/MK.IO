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

    public class Representation
    {
        /// <summary>
        /// Gets or Sets AudioChannelConfiguration
        /// </summary>
        [JsonPropertyName("audio_channel_configuration")]
        public List<AudioChannelConfiguration> AudioChannelConfiguration { get; set; }

        /// <summary>
        /// Gets or Sets Bandwidth
        /// </summary>
        public string Bandwidth { get; set; }

        /// <summary>
        /// Gets or Sets Codecs
        /// </summary>
        public string Codecs { get; set; }

        /// <summary>
        /// Gets or Sets FrameRate
        /// </summary>
        public string FrameRate { get; set; }

        /// <summary>
        /// Gets or Sets Height
        /// </summary>
        public string Height { get; set; }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>


        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets MimeType
        /// </summary>
        public string MimeType { get; set; }

        /// <summary>
        /// Gets or Sets Sar
        /// </summary>
        public string Sar { get; set; }

        /// <summary>
        /// Gets or Sets ScanType
        /// </summary>
        public string ScanType { get; set; }

        /// <summary>
        /// Gets or Sets StartsWithSAP
        /// </summary>
        public string StartsWithSAP { get; set; }

        /// <summary>
        /// Gets or Sets Width
        /// </summary>
        public string Width { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Representation {\n");
            sb.Append("  AudioChannelConfiguration: ").Append(AudioChannelConfiguration).Append("\n");
            sb.Append("  Bandwidth: ").Append(Bandwidth).Append("\n");
            sb.Append("  Codecs: ").Append(Codecs).Append("\n");
            sb.Append("  FrameRate: ").Append(FrameRate).Append("\n");
            sb.Append("  Height: ").Append(Height).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  MimeType: ").Append(MimeType).Append("\n");
            sb.Append("  Sar: ").Append(Sar).Append("\n");
            sb.Append("  ScanType: ").Append(ScanType).Append("\n");
            sb.Append("  StartsWithSAP: ").Append(StartsWithSAP).Append("\n");
            sb.Append("  Width: ").Append(Width).Append("\n");
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
