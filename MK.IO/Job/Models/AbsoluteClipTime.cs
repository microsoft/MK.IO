// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MK.IO.Models
{

    /// <summary>
    /// 
    /// </summary>
    public class AbsoluteClipTime : JobInputTime
    {
        public AbsoluteClipTime(TimeSpan time)
        {
            Time = time;
        }

        [JsonPropertyName("@odata.type")]
        internal override string OdataType => "#Microsoft.Media.AbsoluteClipTime";

        /// <summary>
        /// The time position on the timeline of the input media. It is usually specified as an ISO8601 period. e.g PT30S for 30 seconds.
        /// </summary>
        /// <value>The time position on the timeline of the input media. It is usually specified as an ISO8601 period. e.g PT30S for 30 seconds.</value>
        public TimeSpan Time { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AbsoluteClipTime {\n");
            sb.Append("  OdataType: ").Append(OdataType).Append("\n");
            sb.Append("  Time: ").Append(Time).Append("\n");
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
