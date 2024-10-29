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
    public class AssetFileAccessInfoSchema
    {
        /// <summary>
        /// The name of the container within the storage account.
        /// </summary>
        /// <value>The name of the container within the storage account.</value>
        [DataMember(Name = "containerName", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "containerName")]
        public string ContainerName { get; set; }

        /// <summary>
        /// A JWT token to authenticate the request.
        /// </summary>
        /// <value>A JWT token to authenticate the request.</value>
        [DataMember(Name = "jwt", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "jwt")]
        public string Jwt { get; set; }

        /// <summary>
        /// The name of the storage account.
        /// </summary>
        /// <value>The name of the storage account.</value>
        [DataMember(Name = "storageAccountName", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "storageAccountName")]
        public string StorageAccountName { get; set; }

        /// <summary>
        /// Optional subpath for instances where your asset is not in the root of the container.
        /// </summary>
        /// <value>Optional subpath for instances where your asset is not in the root of the container.</value>
        [DataMember(Name = "subPath", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "subPath")]
        public string SubPath { get; set; }

        /// <summary>
        /// The URL to use to access the container.
        /// </summary>
        /// <value>The URL to use to access the container.</value>
        [DataMember(Name = "url", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AssetFileAccessInfoSchema {\n");
            sb.Append("  ContainerName: ").Append(ContainerName).Append("\n");
            sb.Append("  Jwt: ").Append(Jwt).Append("\n");
            sb.Append("  StorageAccountName: ").Append(StorageAccountName).Append("\n");
            sb.Append("  SubPath: ").Append(SubPath).Append("\n");
            sb.Append("  Url: ").Append(Url).Append("\n");
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
