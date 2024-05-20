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
    public class HeadSchema
    {
        /// <summary>
        /// Gets or Sets AvailabilityStartTime
        /// </summary>
        [DataMember(Name = "availabilityStartTime", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "availabilityStartTime")]
        public DateTime? AvailabilityStartTime { get; set; }

        /// <summary>
        /// Gets or Sets ClientManifestRelativePath
        /// </summary>
        [DataMember(Name = "clientManifestRelativePath", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "clientManifestRelativePath")]
        public string ClientManifestRelativePath { get; set; }

        /// <summary>
        /// Gets or Sets CompatVersion
        /// </summary>
        [DataMember(Name = "compatVersion", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "compatVersion")]
        public string CompatVersion { get; set; }

        /// <summary>
        /// Gets or Sets Extra
        /// </summary>
        [DataMember(Name = "extra", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "extra")]
        public Dictionary<string, Object> Extra { get; set; }

        /// <summary>
        /// Gets or Sets Formats
        /// </summary>
        [DataMember(Name = "formats", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "formats")]
        public string Formats { get; set; }

        /// <summary>
        /// Gets or Sets FragmentsPerHLSSegment
        /// </summary>
        [DataMember(Name = "fragmentsPerHLSSegment", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "fragmentsPerHLSSegment")]
        public string FragmentsPerHLSSegment { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class HeadSchema {\n");
            sb.Append("  AvailabilityStartTime: ").Append(AvailabilityStartTime).Append("\n");
            sb.Append("  ClientManifestRelativePath: ").Append(ClientManifestRelativePath).Append("\n");
            sb.Append("  CompatVersion: ").Append(CompatVersion).Append("\n");
            sb.Append("  Extra: ").Append(Extra).Append("\n");
            sb.Append("  Formats: ").Append(Formats).Append("\n");
            sb.Append("  FragmentsPerHLSSegment: ").Append(FragmentsPerHLSSegment).Append("\n");
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
