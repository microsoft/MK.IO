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
    public class TextStreamSchema
    {
        /// <summary>
        /// Gets or Sets Scheme
        /// </summary>
        [DataMember(Name = "Scheme", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "Scheme")]
        public string Scheme { get; set; }

        /// <summary>
        /// Gets or Sets ManifestOutput
        /// </summary>
        [DataMember(Name = "manifestOutput", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "manifestOutput")]
        public string ManifestOutput { get; set; }

        /// <summary>
        /// Gets or Sets ParentTrackName
        /// </summary>
        [DataMember(Name = "parentTrackName", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "parentTrackName")]
        public string ParentTrackName { get; set; }

        /// <summary>
        /// Gets or Sets Src
        /// </summary>
        [DataMember(Name = "src", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "src")]
        public string Src { get; set; }

        /// <summary>
        /// Gets or Sets SystemBitrate
        /// </summary>
        [DataMember(Name = "systemBitrate", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "systemBitrate")]
        public string SystemBitrate { get; set; }

        /// <summary>
        /// Gets or Sets Timescale
        /// </summary>
        [DataMember(Name = "timescale", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "timescale")]
        public string Timescale { get; set; }

        /// <summary>
        /// Gets or Sets TrackID
        /// </summary>
        [DataMember(Name = "trackID", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "trackID")]
        public string TrackID { get; set; }

        /// <summary>
        /// Gets or Sets TrackName
        /// </summary>
        [DataMember(Name = "trackName", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "trackName")]
        public string TrackName { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TextStreamSchema {\n");
            sb.Append("  Scheme: ").Append(Scheme).Append("\n");
            sb.Append("  ManifestOutput: ").Append(ManifestOutput).Append("\n");
            sb.Append("  ParentTrackName: ").Append(ParentTrackName).Append("\n");
            sb.Append("  Src: ").Append(Src).Append("\n");
            sb.Append("  SystemBitrate: ").Append(SystemBitrate).Append("\n");
            sb.Append("  Timescale: ").Append(Timescale).Append("\n");
            sb.Append("  TrackID: ").Append(TrackID).Append("\n");
            sb.Append("  TrackName: ").Append(TrackName).Append("\n");
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
