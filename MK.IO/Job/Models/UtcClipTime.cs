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
    public class UtcClipTime : JobInputTime
    {
        public UtcClipTime(DateTime time)
        {
            Time = time;
        }

        [JsonProperty("@odata.type")]
        internal override string OdataType => "#Microsoft.Media.UtcClipTime";

        /// <summary>
        /// The time position on the timeline of the input media based on Utc time.
        /// </summary>
        /// <value>The time position on the timeline of the input media based on Utc time.</value>
        [DataMember(Name = "time", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "time")]
        public DateTime Time { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class UtcClipTime {\n");
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
            return JsonConvert.SerializeObject(this, ConverterLE.Settings);
        }

    }
}
