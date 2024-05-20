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
    public class Period
    {
        /// <summary>
        /// Gets or Sets AdaptationSet
        /// </summary>
        [DataMember(Name = "adaptation_set", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "adaptation_set")]
        public List<AdaptationSet> AdaptationSet { get; set; }

        /// <summary>
        /// Gets or Sets AssetIdentifier
        /// </summary>
        [DataMember(Name = "asset_identifier", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "asset_identifier")]
        public AssetIdentifier AssetIdentifier { get; set; }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets ResourceType
        /// </summary>
        [DataMember(Name = "resource_type", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "resource_type")]
        public string ResourceType { get; set; }

        /// <summary>
        /// Gets or Sets Start
        /// </summary>
        [DataMember(Name = "start", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "start")]
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
            return JsonConvert.SerializeObject(this, ConverterLE.Settings);
        }

    }
}
