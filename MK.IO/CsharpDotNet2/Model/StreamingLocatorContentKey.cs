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
    public class StreamingLocatorContentKey
    {
        /// <summary>
        /// The id of the content key
        /// </summary>
        /// <value>The id of the content key</value>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// The label reference in the streaming policy
        /// </summary>
        /// <value>The label reference in the streaming policy</value>
        [DataMember(Name = "labelReferenceInStreamingPolicy", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "labelReferenceInStreamingPolicy")]
        public string LabelReferenceInStreamingPolicy { get; set; }

        /// <summary>
        /// The name of the policy
        /// </summary>
        /// <value>The name of the policy</value>
        [DataMember(Name = "policyName", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "policyName")]
        public string PolicyName { get; private set; }

        /// <summary>
        /// Not currently supported. The tracks which use this content key
        /// </summary>
        /// <value>Not currently supported. The tracks which use this content key</value>
        [DataMember(Name = "tracks", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "tracks")]
        [Obsolete] public List<TrackSelection> Tracks { get; set; }

        /// <summary>
        /// The streaming locator content key type
        /// </summary>
        /// <value>The streaming locator content key type</value>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "type")]
        public StreamingLocatorContentKeyType Type { get; private set; }

        /// <summary>
        /// The value of the content key
        /// </summary>
        /// <value>The value of the content key</value>
        [DataMember(Name = "value", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class StreamingLocatorContentKey {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  LabelReferenceInStreamingPolicy: ").Append(LabelReferenceInStreamingPolicy).Append("\n");
            sb.Append("  PolicyName: ").Append(PolicyName).Append("\n");
            sb.Append("  Tracks: ").Append(Tracks).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
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
