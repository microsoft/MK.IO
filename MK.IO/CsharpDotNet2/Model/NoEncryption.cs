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
    public class NoEncryption
    {
        /// <summary>
        /// Gets or Sets EnabledProtocols
        /// </summary>
        [DataMember(Name = "enabledProtocols", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "enabledProtocols")]
        public EnabledProtocols EnabledProtocols { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class NoEncryption {\n");
            sb.Append("  EnabledProtocols: ").Append(EnabledProtocols).Append("\n");
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
