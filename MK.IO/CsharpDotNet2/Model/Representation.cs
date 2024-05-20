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
    public class Representation
    {
        /// <summary>
        /// Gets or Sets AudioChannelConfiguration
        /// </summary>
        [DataMember(Name = "audio_channel_configuration", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "audio_channel_configuration")]
        public List<AudioChannelConfiguration> AudioChannelConfiguration { get; set; }

        /// <summary>
        /// Gets or Sets Bandwidth
        /// </summary>
        [DataMember(Name = "bandwidth", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "bandwidth")]
        public string Bandwidth { get; set; }

        /// <summary>
        /// Gets or Sets Codecs
        /// </summary>
        [DataMember(Name = "codecs", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "codecs")]
        public string Codecs { get; set; }

        /// <summary>
        /// Gets or Sets FrameRate
        /// </summary>
        [DataMember(Name = "frameRate", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "frameRate")]
        public string FrameRate { get; set; }

        /// <summary>
        /// Gets or Sets Height
        /// </summary>
        [DataMember(Name = "height", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "height")]
        public string Height { get; set; }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets MimeType
        /// </summary>
        [DataMember(Name = "mimeType", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "mimeType")]
        public string MimeType { get; set; }

        /// <summary>
        /// Gets or Sets Sar
        /// </summary>
        [DataMember(Name = "sar", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "sar")]
        public string Sar { get; set; }

        /// <summary>
        /// Gets or Sets ScanType
        /// </summary>
        [DataMember(Name = "scanType", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "scanType")]
        public string ScanType { get; set; }

        /// <summary>
        /// Gets or Sets StartsWithSAP
        /// </summary>
        [DataMember(Name = "startsWithSAP", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "startsWithSAP")]
        public string StartsWithSAP { get; set; }

        /// <summary>
        /// Gets or Sets Width
        /// </summary>
        [DataMember(Name = "width", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "width")]
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
            return JsonConvert.SerializeObject(this, ConverterLE.Settings);
        }

    }
}
