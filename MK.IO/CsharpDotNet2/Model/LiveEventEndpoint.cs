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
    public class LiveEventEndpoint
    {
        /// <summary>
        /// The streaming protocol for the endpoint. Possible values include: 'SRT', 'RTMP'.
        /// </summary>
        /// <value>The streaming protocol for the endpoint. Possible values include: 'SRT', 'RTMP'.</value>
        [DataMember(Name = "protocol", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "protocol")]
        public string Protocol { get; set; }

        /// <summary>
        /// The IP address or DNS with port and protocol
        /// </summary>
        /// <value>The IP address or DNS with port and protocol</value>
        [DataMember(Name = "url", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class LiveEventEndpoint {\n");
            sb.Append("  Protocol: ").Append(Protocol).Append("\n");
            sb.Append("  Url: ").Append(Url).Append("\n");
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
