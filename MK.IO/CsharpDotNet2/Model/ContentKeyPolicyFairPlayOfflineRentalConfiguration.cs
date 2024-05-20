// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MK.IO.Models
{

    /// <summary>
    /// Offline rental policy
    /// </summary>
    [DataContract]
    public class ContentKeyPolicyFairPlayOfflineRentalConfiguration
    {
        /// <summary>
        /// Playback duration
        /// </summary>
        /// <value>Playback duration</value>
        [DataMember(Name = "playbackDurationSeconds", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "playbackDurationSeconds")]
        public long? PlaybackDurationSeconds { get; set; }

        /// <summary>
        /// Storage duration
        /// </summary>
        /// <value>Storage duration</value>
        [DataMember(Name = "storageDurationSeconds", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "storageDurationSeconds")]
        public long? StorageDurationSeconds { get; set; }

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ContentKeyPolicyFairPlayOfflineRentalConfiguration {\n");
            sb.Append("  PlaybackDurationSeconds: ").Append(PlaybackDurationSeconds).Append("\n");
            sb.Append("  StorageDurationSeconds: ").Append(StorageDurationSeconds).Append("\n");
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
