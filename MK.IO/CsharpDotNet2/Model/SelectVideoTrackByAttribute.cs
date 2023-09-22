using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MK.IO.Models
{

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class SelectVideoTrackByAttribute
    {
        /// <summary>
        /// The TrackAttribute to filter the tracks by.
        /// </summary>
        /// <value>The TrackAttribute to filter the tracks by.</value>
        [DataMember(Name = "attribute", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "attribute")]
        public string Attribute { get; set; }

        /// <summary>
        /// The type of AttributeFilter to apply to the TrackAttribute in order to select the tracks.
        /// </summary>
        /// <value>The type of AttributeFilter to apply to the TrackAttribute in order to select the tracks.</value>
        [DataMember(Name = "filter", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "filter")]
        public string Filter { get; set; }

        /// <summary>
        /// The value to filter the tracks by.
        /// </summary>
        /// <value>The value to filter the tracks by.</value>
        [DataMember(Name = "filterValue", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "filterValue")]
        public string FilterValue { get; set; }

        /// <summary>
        /// The discriminator for derived types.
        /// </summary>
        /// <value>The discriminator for derived types.</value>
        [DataMember(Name = "odatatype", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "odatatype")]
        public string Odatatype { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SelectVideoTrackByAttribute {\n");
            sb.Append("  Attribute: ").Append(Attribute).Append("\n");
            sb.Append("  Filter: ").Append(Filter).Append("\n");
            sb.Append("  FilterValue: ").Append(FilterValue).Append("\n");
            sb.Append("  Odatatype: ").Append(Odatatype).Append("\n");
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