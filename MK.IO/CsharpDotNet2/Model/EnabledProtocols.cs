// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.



using System.Text;
using System.Text.Json;

namespace MK.IO.Models
{

    /// <summary>
    /// 
    /// </summary>

    public class EnabledProtocols
    {
        /// <summary>
        /// Enable Dash protocol
        /// </summary>
        /// <value>Enable Dash protocol</value>
        public bool? Dash { get; set; }

        /// <summary>
        /// Enable download protocol
        /// </summary>
        /// <value>Enable download protocol</value>
        public bool? Download { get; set; }

        /// <summary>
        /// Enable HLS protocol
        /// </summary>
        /// <value>Enable HLS protocol</value>
        public bool? Hls { get; set; }

        /// <summary>
        /// Smooth streaming is not supported and the value of this field is ignored.
        /// </summary>
        /// <value>Smooth streaming is not supported and the value of this field is ignored.</value>
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
            return JsonSerializer.Serialize(this, ConverterLE.Settings);
        }

    }
}
