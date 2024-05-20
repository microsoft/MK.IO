// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.



using System.Text;
using System.Text.Json;

namespace MK.IO.Models
{

    /// <summary>
    /// 
    /// </summary>

    public class LiveEventEndpoint
    {
        /// <summary>
        /// The streaming protocol for the endpoint. Possible values include: 'SRT', 'RTMP'.
        /// </summary>
        /// <value>The streaming protocol for the endpoint. Possible values include: 'SRT', 'RTMP'.</value>
        public string Protocol { get; set; }

        /// <summary>
        /// The IP address or DNS with port and protocol
        /// </summary>
        /// <value>The IP address or DNS with port and protocol</value>
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
            return JsonSerializer.Serialize(this, ConverterLE.Settings);
        }

    }
}
