// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.



using System.Text;
using System.Text.Json;

namespace MK.IO.Models
{

    /// <summary>
    /// 
    /// </summary>

    public class CencDrmConfiguration
    {
        /// <summary>
        /// Gets or Sets PlayReady
        /// </summary>
        public StreamingPolicyPlayReadyConfiguration PlayReady { get; set; }

        /// <summary>
        /// Gets or Sets Widevine
        /// </summary>
        public StreamingPolicyWidevineConfiguration Widevine { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CencDrmConfiguration {\n");
            sb.Append("  PlayReady: ").Append(PlayReady).Append("\n");
            sb.Append("  Widevine: ").Append(Widevine).Append("\n");
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
