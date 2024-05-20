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
    public class StreamingPolicyPlayReadyConfiguration
    {
        /// <summary>
        /// The custom license acquisition URL template for a PlayReady license delivery service.
        /// </summary>
        /// <value>The custom license acquisition URL template for a PlayReady license delivery service.</value>
        [DataMember(Name = "customLicenseAcquisitionUrlTemplate", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "customLicenseAcquisitionUrlTemplate")]
        public string CustomLicenseAcquisitionUrlTemplate { get; set; }

        /// <summary>
        /// The custom attributes for PlayReady.
        /// </summary>
        /// <value>The custom attributes for PlayReady.</value>
        [DataMember(Name = "playReadyCustomAttributes", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "playReadyCustomAttributes")]
        public string PlayReadyCustomAttributes { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class StreamingPolicyPlayReadyConfiguration {\n");
            sb.Append("  CustomLicenseAcquisitionUrlTemplate: ").Append(CustomLicenseAcquisitionUrlTemplate).Append("\n");
            sb.Append("  PlayReadyCustomAttributes: ").Append(PlayReadyCustomAttributes).Append("\n");
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
