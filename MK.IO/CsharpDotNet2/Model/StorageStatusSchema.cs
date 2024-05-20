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
    public class StorageStatusSchema
    {
        /// <summary>
        /// The unique identifier of the credential that is currently active for the storage account.
        /// </summary>
        /// <value>The unique identifier of the credential that is currently active for the storage account.</value>
        [DataMember(Name = "activeCredentialId", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "activeCredentialId")]
        public Guid? ActiveCredentialId { get; private set; }

        /// <summary>
        /// The state of the Azure Private Connection, if enabled.
        /// </summary>
        /// <value>The state of the Azure Private Connection, if enabled.</value>
        [DataMember(Name = "privateLinkServiceConnectionStatus", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "privateLinkServiceConnectionStatus")]
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
            return JsonConvert.SerializeObject(this, ConverterLE.Settings);
        }

    }
}
