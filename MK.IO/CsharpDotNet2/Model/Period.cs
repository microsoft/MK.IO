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

    public class Period
    {
        /// <summary>
        /// Gets or Sets AdaptationSet
        /// </summary>
        [JsonPropertyName("adaptation_set")]
        public List<AdaptationSet> AdaptationSet { get; set; }

        /// <summary>
        /// Gets or Sets AssetIdentifier
        /// </summary>
        [JsonPropertyName("asset_identifier")]
        public AssetIdentifier AssetIdentifier { get; set; }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>


        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets ResourceType
        /// </summary>
        [JsonPropertyName("resource_type")]
        public string ResourceType { get; set; }

        /// <summary>
        /// Gets or Sets Start
        /// </summary>
        public string Start { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Period {\n");
            sb.Append("  AdaptationSet: ").Append(AdaptationSet).Append("\n");
            sb.Append("  AssetIdentifier: ").Append(AssetIdentifier).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  ResourceType: ").Append(ResourceType).Append("\n");
            sb.Append("  Start: ").Append(Start).Append("\n");
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
