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
    public class CommonEncryptionCenc
    {
        /// <summary>
        /// Gets or Sets ClearKeyEncryptionConfiguration
        /// </summary>
        [DataMember(Name = "clearKeyEncryptionConfiguration", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "clearKeyEncryptionConfiguration")]
        public ClearKeyEncryptionConfiguration ClearKeyEncryptionConfiguration { get; set; }

        /// <summary>
        /// This represents which tracks should *not* be encrypted.
        /// </summary>
        /// <value>This represents which tracks should *not* be encrypted.</value>
        [DataMember(Name = "clearTracks", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "clearTracks")]
        public List<TrackSelection> ClearTracks { get; set; }

        /// <summary>
        /// Gets or Sets ContentKeys
        /// </summary>
        [DataMember(Name = "contentKeys", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "contentKeys")]
        public StreamingPolicyContentKeys ContentKeys { get; set; }

        /// <summary>
        /// Gets or Sets Drm
        /// </summary>
        [DataMember(Name = "drm", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "drm")]
        public CencDrmConfiguration Drm { get; set; }

        /// <summary>
        /// Gets or Sets EnabledProtocols
        /// </summary>
        [DataMember(Name = "enabledProtocols", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "enabledProtocols")]
        public EnabledProtocols EnabledProtocols { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CommonEncryptionCenc {\n");
            sb.Append("  ClearKeyEncryptionConfiguration: ").Append(ClearKeyEncryptionConfiguration).Append("\n");
            sb.Append("  ClearTracks: ").Append(ClearTracks).Append("\n");
            sb.Append("  ContentKeys: ").Append(ContentKeys).Append("\n");
            sb.Append("  Drm: ").Append(Drm).Append("\n");
            sb.Append("  EnabledProtocols: ").Append(EnabledProtocols).Append("\n");
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
