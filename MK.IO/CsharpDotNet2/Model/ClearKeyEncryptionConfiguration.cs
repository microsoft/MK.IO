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
    public class ClearKeyEncryptionConfiguration
    {
        /// <summary>
        /// The custom license acquisition URL template for a Clear Key license delivery service.
        /// </summary>
        /// <value>The custom license acquisition URL template for a Clear Key license delivery service.</value>
        [DataMember(Name = "customKeysAcquisitionUrlTemplate", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "customKeysAcquisitionUrlTemplate")]
        public string CustomKeysAcquisitionUrlTemplate { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ClearKeyEncryptionConfiguration {\n");
            sb.Append("  CustomKeysAcquisitionUrlTemplate: ").Append(CustomKeysAcquisitionUrlTemplate).Append("\n");
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
