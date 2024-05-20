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
    [DataContract]
    public class IPAccessControl
    {
        /// <summary>
        /// The IP ranges that will be allowed to access the preview.  If empty, all IPs will be allowed.
        /// </summary>
        /// <value>The IP ranges that will be allowed to access the preview.  If empty, all IPs will be allowed.</value>
        [DataMember(Name = "allow", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "allow")]
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
            return JsonConvert.SerializeObject(this, ConverterLE.Settings);
        }

    }
}
