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
    public class StreamingPolicyWidevineConfiguration
    {
        /// <summary>
        /// The custom license acquisition URL template for a Widevine license delivery service.
        /// </summary>
        /// <value>The custom license acquisition URL template for a Widevine license delivery service.</value>
        [DataMember(Name = "customLicenseAcquisitionUrlTemplate", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "customLicenseAcquisitionUrlTemplate")]
        public string CustomLicenseAcquisitionUrlTemplate { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class StreamingPolicyWidevineConfiguration {\n");
            sb.Append("  CustomLicenseAcquisitionUrlTemplate: ").Append(CustomLicenseAcquisitionUrlTemplate).Append("\n");
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
