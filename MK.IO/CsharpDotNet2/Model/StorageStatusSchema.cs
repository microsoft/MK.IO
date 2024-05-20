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

    public class StorageStatusSchema
    {
        /// <summary>
        /// The unique identifier of the credential that is currently active for the storage account.
        /// </summary>
        /// <value>The unique identifier of the credential that is currently active for the storage account.</value>
        [JsonInclude]
        public Guid? ActiveCredentialId { get; private set; }

        /// <summary>
        /// The state of the Azure Private Connection, if enabled.
        /// </summary>
        /// <value>The state of the Azure Private Connection, if enabled.</value>
        [JsonInclude]
        public PrivateLinkServiceConnectionState? PrivateLinkServiceConnectionStatus { get; private set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class StorageStatusSchema {\n");
            sb.Append("  ActiveCredentialId: ").Append(ActiveCredentialId).Append("\n");
            sb.Append("  PrivateLinkServiceConnectionStatus: ").Append(PrivateLinkServiceConnectionStatus).Append("\n");
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
