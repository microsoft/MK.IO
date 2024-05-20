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
    public class EnabledProtocols
    {
        /// <summary>
        /// Enable Dash protocol
        /// </summary>
        /// <value>Enable Dash protocol</value>
        [DataMember(Name = "dash", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "dash")]
        public bool? Dash { get; set; }

        /// <summary>
        /// Enable download protocol
        /// </summary>
        /// <value>Enable download protocol</value>
        [DataMember(Name = "download", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "download")]
        public bool? Download { get; set; }

        /// <summary>
        /// Enable HLS protocol
        /// </summary>
        /// <value>Enable HLS protocol</value>
        [DataMember(Name = "hls", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "hls")]
        public bool? Hls { get; set; }

        /// <summary>
        /// Smooth streaming is not supported and the value of this field is ignored.
        /// </summary>
        /// <value>Smooth streaming is not supported and the value of this field is ignored.</value>
        [DataMember(Name = "smoothStreaming", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "smoothStreaming")]
        [Obsolete] public bool? SmoothStreaming { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class EnabledProtocols {\n");
            sb.Append("  Dash: ").Append(Dash).Append("\n");
            sb.Append("  Download: ").Append(Download).Append("\n");
            sb.Append("  Hls: ").Append(Hls).Append("\n");
            sb.Append("  SmoothStreaming: ").Append(SmoothStreaming).Append("\n");
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
