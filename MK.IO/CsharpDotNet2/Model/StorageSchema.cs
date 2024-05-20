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
    public class StorageSchema
    {
        /// <summary>
        /// Gets or Sets AzureStorageConfiguration
        /// </summary>
        [DataMember(Name = "azureStorageConfiguration", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "azureStorageConfiguration")]
        public BlobStorageAzureProperties AzureStorageConfiguration { get; set; }

        /// <summary>
        /// User relevant description of this storage account
        /// </summary>
        /// <value>User relevant description of this storage account</value>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// The name of the location in which the storage is located. This field must match the location in which the user's subscription is provisioned.
        /// </summary>
        /// <value>The name of the location in which the storage is located. This field must match the location in which the user's subscription is provisioned.</value>
        [DataMember(Name = "location", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "location")]
        public string Location { get; set; }

        /// <summary>
        /// The name of the storage account. This is the name that you will use to reference this storage account when creating resources throughout the rest of the API.         The name must be unique within the subscription that created the storage account. You may designate the same storage endpoint as many times as you wish, only this          name must be unique.         
        /// </summary>
        /// <value>The name of the storage account. This is the name that you will use to reference this storage account when creating resources throughout the rest of the API.         The name must be unique within the subscription that created the storage account. You may designate the same storage endpoint as many times as you wish, only this          name must be unique.         </value>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Must be set to 'Microsoft.Storage'.
        /// </summary>
        /// <value>Must be set to 'Microsoft.Storage'.</value>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class StorageSchema {\n");
            sb.Append("  AzureStorageConfiguration: ").Append(AzureStorageConfiguration).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Location: ").Append(Location).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
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
