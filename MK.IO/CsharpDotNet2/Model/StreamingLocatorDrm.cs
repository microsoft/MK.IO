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
    public class StreamingLocatorDrm
    {
        /// <summary>
        /// The URL for obtaining the streaming certificate.
        /// </summary>
        /// <value>The URL for obtaining the streaming certificate.</value>
        [DataMember(Name = "certificateUrl", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "certificateUrl")]
        public string CertificateUrl { get; set; }

        /// <summary>
        /// The license acquisition URL for the DRM.
        /// </summary>
        /// <value>The license acquisition URL for the DRM.</value>
        [DataMember(Name = "licenseAcquisitionUrl", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "licenseAcquisitionUrl")]
        public string LicenseAcquisitionUrl { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class StreamingLocatorDrm {\n");
            sb.Append("  CertificateUrl: ").Append(CertificateUrl).Append("\n");
            sb.Append("  LicenseAcquisitionUrl: ").Append(LicenseAcquisitionUrl).Append("\n");
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
