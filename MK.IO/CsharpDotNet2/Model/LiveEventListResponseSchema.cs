

using System.Text;
using System.Text.Json;

namespace MK.IO.Models
{

    /// <summary>
    /// 
    /// </summary>

    public class LiveEventListResponseSchema
    {
        /// <summary>
        /// A list of live events.
        /// </summary>
        /// <value>A list of live events.</value>
        public List<LiveEventSchema> Value { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class LiveEventListResponseSchema {\n");
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
