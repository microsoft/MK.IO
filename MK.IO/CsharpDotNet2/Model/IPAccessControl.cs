

using System.Text;
using System.Text.Json;

namespace MK.IO.Models
{

    /// <summary>
    /// 
    /// </summary>

    public class IPAccessControl
    {
        /// <summary>
        /// The IP ranges that will be allowed to access the preview.  If empty, all IPs will be allowed.
        /// </summary>
        /// <value>The IP ranges that will be allowed to access the preview.  If empty, all IPs will be allowed.</value>
        public List<IPRange> Allow { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class IPAccessControl {\n");
            sb.Append("  Allow: ").Append(Allow).Append("\n");
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
