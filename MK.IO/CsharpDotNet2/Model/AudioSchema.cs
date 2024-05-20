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
    public class AudioSchema
    {
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
        /// Gets or Sets SystemLanguage
        /// </summary>
        [DataMember(Name = "systemLanguage", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "systemLanguage")]
        public string SystemLanguage { get; set; }

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
            sb.Append("class AudioSchema {\n");
            sb.Append("  Src: ").Append(Src).Append("\n");
            sb.Append("  SystemBitrate: ").Append(SystemBitrate).Append("\n");
            sb.Append("  SystemLanguage: ").Append(SystemLanguage).Append("\n");
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
