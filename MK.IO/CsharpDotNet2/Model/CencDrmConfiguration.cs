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
    public class CencDrmConfiguration
    {
        /// <summary>
        /// Gets or Sets PlayReady
        /// </summary>
        [DataMember(Name = "playReady", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "playReady")]
        public StreamingPolicyPlayReadyConfiguration PlayReady { get; set; }

        /// <summary>
        /// Gets or Sets Widevine
        /// </summary>
        [DataMember(Name = "widevine", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "widevine")]
        public StreamingPolicyWidevineConfiguration Widevine { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CencDrmConfiguration {\n");
            sb.Append("  PlayReady: ").Append(PlayReady).Append("\n");
            sb.Append("  Widevine: ").Append(Widevine).Append("\n");
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
