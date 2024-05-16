

using System.Text;
using System.Text.Json;

namespace MK.IO.Models
{

    /// <summary>
    /// 
    /// </summary>

    public class TrackPropertyCondition
    {
        /// <summary>
        /// Track property operation. Only equality is supported.
        /// </summary>
        /// <value>Track property operation. Only equality is supported.</value>
        public TrackPropertyConditionOperationType Operation { get; set; }

        /// <summary>
        /// Track property type
        /// </summary>
        /// <value>Track property type</value>
        public TrackPropertyConditionPropertyType Property { get; set; }

        /// <summary>
        /// Track property value
        /// </summary>
        /// <value>Track property value</value>
        public string Value { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TrackPropertyCondition {\n");
            sb.Append("  Operation: ").Append(Operation).Append("\n");
            sb.Append("  Property: ").Append(Property).Append("\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
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
