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
    public class AssetSchema
    {
        /// <summary>
        /// Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}
        /// </summary>
        /// <value>Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}</value>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "id")]
        public string Id { get; private set; }

        /// <summary>
        /// A dictionary of labels associated with the resource.
        /// Maximum number of labels: 32.
        /// Maximum length of a label or value: 256 characters.
        /// Label: alphanumeric, hyphens and underscores.
        /// Value: alphanumeric, hyphens, underscores and spaces.
        /// </summary>
        /// <value>A dictionary of labels associated with the resource. Maximum number of labels: 32. Maximum length of a label or value: 256 characters. Label: alphanumeric, hyphens and underscores. Value: alphanumeric, hyphens, underscores and spaces.</value></value>
        [DataMember(Name = "labels", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "labels")]
        public Dictionary<string, string> Labels { get; set; }

        /// <summary>
        /// The name of the resource
        /// </summary>
        /// <value>The name of the resource</value>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "name")]
        public string Name { get; private set; }

        /// <summary>
        /// Gets or Sets Properties
        /// </summary>
        [DataMember(Name = "properties", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "properties")]
        public AssetProperties Properties { get; set; }

        /// <summary>
        /// Gets or Sets SystemData
        /// </summary>
        [DataMember(Name = "systemData", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "systemData")]
        public SystemDataSchema SystemData { get; private set; }

        /// <summary>
        /// The type of the resource. E.g. \"Microsoft.Media/mediaservices/assets\"
        /// </summary>
        /// <value>The type of the resource. E.g. \"Microsoft.Media/mediaservices/assets\"</value>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "type")]
        public string Type { get; private set; }

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AssetSchema {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Labels: ").Append(Labels).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Properties: ").Append(Properties).Append("\n");
            sb.Append("  SystemData: ").Append(SystemData).Append("\n");
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
