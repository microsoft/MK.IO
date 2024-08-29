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
    public class FirstQuality
    {
        /// <summary>
        /// Denotes the target video bitrate to be used when starting playback of an HLS manifest.         The video representation with the bitrate closest to the defined bitrate will be presented first among the available representations in the HLS manifest.
        /// </summary>
        /// <value>Denotes the target video bitrate to be used when starting playback of an HLS manifest.         The video representation with the bitrate closest to the defined bitrate will be presented first among the available representations in the HLS manifest.</value>
        [DataMember(Name = "bitrate", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "bitrate")]
        public int? Bitrate { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class FirstQuality {\n");
            sb.Append("  Bitrate: ").Append(Bitrate).Append("\n");
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
