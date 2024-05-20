// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.



using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MK.IO.Models
{

    /// <summary>
    /// 
    /// </summary>

    public class AzureCredential
    {
        /// <summary>
        /// SAS Token for Azure Storage Account, including leading ?
        /// </summary>
        /// <value>SAS Token for Azure Storage Account, including leading ?</value>
        public string SasToken { get; set; }

        /// <summary>
        /// Sanitized token returned in responses from the server. This is the same as the sasToken, but with the signature removed.
        /// </summary>
        /// <value>Sanitized token returned in responses from the server. This is the same as the sasToken, but with the signature removed.</value>
        [JsonInclude]
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
            return JsonSerializer.Serialize(this, ConverterLE.Settings);
        }

    }
}
