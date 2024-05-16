

using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MK.IO.Models
{

    /// <summary>
    /// 
    /// </summary>

    public class StreamingPolicySchema
    {
        /// <summary>
        /// Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}
        /// </summary>
        /// <value>Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}</value>
        [JsonInclude]
        public string Id { get; private set; }

        /// <summary>
        /// The name of the resource
        /// </summary>
        /// <value>The name of the resource</value>
        [JsonInclude]
        public string Name { get; private set; }

        /// <summary>
        /// Gets or Sets Properties
        /// </summary>
        public StreamingPolicyProperties Properties { get; set; }

        /// <summary>
        /// Gets or Sets SystemData
        /// </summary>
        [JsonInclude]
        public SystemDataSchema SystemData { get; private set; }

        /// <summary>
        /// The type of the resource. E.g. \"Microsoft.Media/mediaservices/assets\"
        /// </summary>
        /// <value>The type of the resource. E.g. \"Microsoft.Media/mediaservices/assets\"</value>
        [JsonInclude]
        public string Type { get; private set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class StreamingPolicySchema {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
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
            return JsonSerializer.Serialize(this, ConverterLE.Settings);
        }

    }
}
