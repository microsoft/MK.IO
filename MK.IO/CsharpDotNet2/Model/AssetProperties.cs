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
    public class AssetProperties
    {
        /// <summary>
        /// An alternate ID of the asset.
        /// </summary>
        /// <value>An alternate ID of the asset.</value>
        [DataMember(Name = "alternateId", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "alternateId")]
        public string AlternateId { get; set; }

        /// <summary>
        /// The Asset ID.
        /// </summary>
        /// <value>The Asset ID.</value>
        [DataMember(Name = "assetId", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "assetId")]
        public Guid? AssetId { get; private set; }

        /// <summary>
        /// The name of the asset blob container.
        /// </summary>
        /// <value>The name of the asset blob container.</value>
        [DataMember(Name = "container", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "container")]
        public string Container { get; set; }

        /// <summary>
        /// This field defines the deletion policy for the underlying storage container.
        /// This determines the behavior when an asset record is deleted. There are two options, 'Delete', and 'Retain'.
        /// A deletion policy of 'Delete' will result in the associated storage container and all its contents being removed
        /// from storage. A deletion policy of 'Retain' will leave the content in-place in your storage account.
        /// If left blank, the default behavior of the system will be to retain content. Once set by the user, this value
        /// can be modified, but not un-set.
        /// </summary>
        /// <value>This field defines the deletion policy for the underlying storage container.
        /// This determines the behavior when an asset record is deleted. There are two options, 'Delete', and 'Retain'.
        /// A deletion policy of 'Delete' will result in the associated storage container and all its contents being removed
        /// from storage. A deletion policy of 'Retain' will leave the content in-place in your storage account.
        /// If left blank, the default behavior of the system will be to retain content. Once set by the user, this value
        /// can be modified, but not un-set.</value>
        [DataMember(Name = "containerDeletionPolicy", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "containerDeletionPolicy")]
        public AssetContainerDeletionPolicyType? ContainerDeletionPolicy { get; set; }

        /// <summary>
        /// The creation date of the Asset.
        /// </summary>
        /// <value>The creation date of the Asset.</value>
        [DataMember(Name = "created", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "created")]
        public DateTime? Created { get; private set; }

        /// <summary>
        /// The Asset description.
        /// </summary>
        /// <value>The Asset description.</value>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Accepted, not supported. The name of the encryption scope to use within your storage container. Errors may be cryptic.
        /// </summary>
        /// <value>Accepted, not supported. The name of the encryption scope to use within your storage container. Errors may be cryptic.</value>
        [DataMember(Name = "encryptionScope", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "encryptionScope")]
        [Obsolete] public string EncryptionScope { get; set; }

        /// <summary>
        /// The last modified date of the Asset.
        /// </summary>
        /// <value>The last modified date of the Asset.</value>
        [DataMember(Name = "lastModified", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "lastModified")]
        public DateTime? LastModified { get; private set; }

        /// <summary>
        /// The name of the storage account.
        /// </summary>
        /// <value>The name of the storage account.</value>
        [DataMember(Name = "storageAccountName", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "storageAccountName")]
        public string StorageAccountName { get; set; }

        /// <summary>
        /// This field was deprecated in the v3 API. Accepted, not supported. Use an encryption scope instead.
        /// </summary>
        /// <value>This field was deprecated in the v3 API. Accepted, not supported. Use an encryption scope instead.</value>
        [DataMember(Name = "storageEncryptionFormat", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "storageEncryptionFormat")]
        [Obsolete] public string StorageEncryptionFormat { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AssetProperties {\n");
            sb.Append("  AlternateId: ").Append(AlternateId).Append("\n");
            sb.Append("  AssetId: ").Append(AssetId).Append("\n");
            sb.Append("  Container: ").Append(Container).Append("\n");
            sb.Append("  ContainerDeletionPolicy: ").Append(ContainerDeletionPolicy).Append("\n");
            sb.Append("  Created: ").Append(Created).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  EncryptionScope: ").Append(EncryptionScope).Append("\n");
            sb.Append("  LastModified: ").Append(LastModified).Append("\n");
            sb.Append("  StorageAccountName: ").Append(StorageAccountName).Append("\n");
            sb.Append("  StorageEncryptionFormat: ").Append(StorageEncryptionFormat).Append("\n");
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
