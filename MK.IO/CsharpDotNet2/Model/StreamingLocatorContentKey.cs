// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.



using System.Text;
using System.Text.Json;

namespace MK.IO.Models
{

    /// <summary>
    /// 
    /// </summary>

    public class StreamingLocatorContentKey
    {
        /// <summary>
        /// The id of the content key
        /// </summary>
        /// <value>The id of the content key</value>


        public string Id { get; set; }

        /// <summary>
        /// The label reference in the streaming policy
        /// </summary>
        /// <value>The label reference in the streaming policy</value>
        public string LabelReferenceInStreamingPolicy { get; set; }

        /// <summary>
        /// The name of the policy
        /// </summary>
        /// <value>The name of the policy</value>
        public string PolicyName { get; set; }

        /// <summary>
        /// Not currently supported. The tracks which use this content key
        /// </summary>
        /// <value>Not currently supported. The tracks which use this content key</value>
        [Obsolete] public List<TrackSelection> Tracks { get; set; }

        /// <summary>
        /// The streaming locator content key type
        /// </summary>
        /// <value>The streaming locator content key type</value>


        public StreamingLocatorContentKeyType Type { get; set; }

        /// <summary>
        /// The value of the content key
        /// </summary>
        /// <value>The value of the content key</value>
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
            return JsonSerializer.Serialize(this, ConverterLE.Settings);
        }

    }
}
