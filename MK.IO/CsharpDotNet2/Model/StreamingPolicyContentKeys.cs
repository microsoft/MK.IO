// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.



using System.Text;
using System.Text.Json;

namespace MK.IO.Models
{

    /// <summary>
    /// 
    /// </summary>

    public class StreamingPolicyContentKeys
    {
        /// <summary>
        /// Gets or Sets DefaultKey
        /// </summary>
        public DefaultKey DefaultKey { get; set; }

        /// <summary>
        /// List of content keys used by the key. Used to assign different keys to different tracks. For instance, using widevine L3 for SD and L1 for HD.
        /// </summary>
        /// <value>List of content keys used by the key. Used to assign different keys to different tracks. For instance, using widevine L3 for SD and L1 for HD.</value>
        public List<StreamingPolicyContentKey> KeyToTrackMappings { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class StreamingPolicyContentKeys {\n");
            sb.Append("  DefaultKey: ").Append(DefaultKey).Append("\n");
            sb.Append("  KeyToTrackMappings: ").Append(KeyToTrackMappings).Append("\n");
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
