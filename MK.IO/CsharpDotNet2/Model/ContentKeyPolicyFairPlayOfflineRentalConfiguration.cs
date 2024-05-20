// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text;
using System.Text.Json;



namespace MK.IO.Models
{

    /// <summary>
    /// Offline rental policy
    /// </summary>

    public class ContentKeyPolicyFairPlayOfflineRentalConfiguration
    {
        /// <summary>
        /// Playback duration
        /// </summary>
        /// <value>Playback duration</value>
        public long? PlaybackDurationSeconds { get; set; }

        /// <summary>
        /// Storage duration
        /// </summary>
        /// <value>Storage duration</value>
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
            return JsonSerializer.Serialize(this, ConverterLE.Settings);
        }
    }
}
