

using System.Text;
using System.Text.Json;

namespace MK.IO.Models
{

    /// <summary>
    /// 
    /// </summary>

    public class StreamingEndpointListResponseSchema
    {
        /// <summary>
        /// A list of streaming endpoints
        /// </summary>
        /// <value>A list of streaming endpoints</value>
        public List<StreamingEndpointSchema> Value { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class StreamingEndpointListResponseSchema {\n");
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
