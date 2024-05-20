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
    public class AzureCredential
    {
        /// <summary>
        /// SAS Token for Azure Storage Account, including leading ?
        /// </summary>
        /// <value>SAS Token for Azure Storage Account, including leading ?</value>
        [DataMember(Name = "sasToken", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "sasToken")]
        public string SasToken { get; set; }

        /// <summary>
        /// Sanitized token returned in responses from the server. This is the same as the sasToken, but with the signature removed.
        /// </summary>
        /// <value>Sanitized token returned in responses from the server. This is the same as the sasToken, but with the signature removed.</value>
        [DataMember(Name = "sasTokenSanitized", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "sasTokenSanitized")]
        public string SasTokenSanitized { get; private set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AzureCredential {\n");
            sb.Append("  SasToken: ").Append(SasToken).Append("\n");
            sb.Append("  SasTokenSanitized: ").Append(SasTokenSanitized).Append("\n");
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
