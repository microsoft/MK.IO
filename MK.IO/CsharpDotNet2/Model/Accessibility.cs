using System.Text;
using System.Text.Json;

namespace MK.IO.Models
{
    /// <summary>
    /// 
    /// </summary>

    public class Accessibility
    {
        /// <summary>
        /// Gets or Sets SchemeIdUri
        /// </summary>
        public string SchemeIdUri { get; set; }

        /// <summary>
        /// Gets or Sets Value
        /// </summary>
        public string Value { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Accessibility {\n");
            sb.Append("  SchemeIdUri: ").Append(SchemeIdUri).Append("\n");
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
