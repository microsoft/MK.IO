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
    public class HlsSettings
    {
        /// <summary>
        /// The characteristics for the HLS setting.
        /// </summary>
        /// <value>The characteristics for the HLS setting.</value>
        [DataMember(Name = "characteristics", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "characteristics")]
        public string Characteristics { get; set; }

        /// <summary>
        /// Default track?
        /// </summary>
        /// <value>Default track?</value>
        [DataMember(Name = "default", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "default")]
        public bool? Default { get; set; } = false;

        /// <summary>
        /// Forced track?
        /// </summary>
        /// <value>Forced track?</value>
        [DataMember(Name = "forced", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "forced")]
        public bool? Forced { get; set; } = false;


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class HlsSettings {\n");
            sb.Append("  Characteristics: ").Append(Characteristics).Append("\n");
            sb.Append("  Default: ").Append(Default).Append("\n");
            sb.Append("  Forced: ").Append(Forced).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Get the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

    }
}
