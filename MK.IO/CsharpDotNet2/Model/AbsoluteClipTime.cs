using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace MK.IO.Models
{

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class AbsoluteClipTime
    {
        /// <summary>
        /// The discriminator for derived types.
        /// </summary>
        /// <value>The discriminator for derived types.</value>
        [DataMember(Name = "@odata.type", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "@odata.type")]
        public string OdataType { get; set; }

        /// <summary>
        /// The time position on the timeline of the input media. It is usually specified as an ISO8601 period. e.g PT30S for 30 seconds.
        /// </summary>
        /// <value>The time position on the timeline of the input media. It is usually specified as an ISO8601 period. e.g PT30S for 30 seconds.</value>
        [DataMember(Name = "time", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "time")]
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
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

    }
}
