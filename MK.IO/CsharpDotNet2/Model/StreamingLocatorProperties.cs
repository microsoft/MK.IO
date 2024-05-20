// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.



using System.Text;
using System.Text.Json;

namespace MK.IO.Models
{

    /// <summary>
    /// 
    /// </summary>

    public class StreamingLocatorProperties
    {
        /// <summary>
        /// The alternative media id of the asset used by this streaming locator
        /// </summary>
        /// <value>The alternative media id of the asset used by this streaming locator</value>
        public string AlternativeMediaId { get; set; }

        /// <summary>
        /// The name of the asset used by this streaming locator
        /// </summary>
        /// <value>The name of the asset used by this streaming locator</value>
        public string AssetName { get; set; }

        /// <summary>
        /// The content keys used by this streaming locator
        /// </summary>
        /// <value>The content keys used by this streaming locator</value>
        public List<StreamingLocatorContentKey> ContentKeys { get; set; }

        /// <summary>
        /// The default content key policy name used by this streaming locator.
        /// </summary>
        /// <value>The default content key policy name used by this streaming locator.</value>
        public string DefaultContentKeyPolicyName { get; set; }

        /// <summary>
        /// The end time of the streaming locator
        /// </summary>
        /// <value>The end time of the streaming locator</value>
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// A list of asset or account filters to apply to the streaming locator.
        /// </summary>
        /// <value>A list of asset or account filters to apply to the streaming locator.</value>
        public List<string> Filters { get; set; }

        /// <summary>
        /// The start time of the streaming locator
        /// </summary>
        /// <value>The start time of the streaming locator</value>
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// The streaming locator id
        /// </summary>
        /// <value>The streaming locator id</value>
        public Guid? StreamingLocatorId { get; set; }

        /// <summary>
        /// The name of the streaming policy used by this streaming locator.
        /// You may specify a custom policy by name, or used one of the predefined policies.
        /// </summary>
        /// <value>
        /// The name of the streaming policy used by this streaming locator.
        /// You may specify a custom policy by name, or used one of the predefined policies.
        /// </value>
        public string StreamingPolicyName { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class StreamingLocatorProperties {\n");
            sb.Append("  AlternativeMediaId: ").Append(AlternativeMediaId).Append("\n");
            sb.Append("  AssetName: ").Append(AssetName).Append("\n");
            sb.Append("  ContentKeys: ").Append(ContentKeys).Append("\n");
            sb.Append("  DefaultContentKeyPolicyName: ").Append(DefaultContentKeyPolicyName).Append("\n");
            sb.Append("  EndTime: ").Append(EndTime).Append("\n");
            sb.Append("  Filters: ").Append(Filters).Append("\n");
            sb.Append("  StartTime: ").Append(StartTime).Append("\n");
            sb.Append("  StreamingLocatorId: ").Append(StreamingLocatorId).Append("\n");
            sb.Append("  StreamingPolicyName: ").Append(StreamingPolicyName).Append("\n");
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
