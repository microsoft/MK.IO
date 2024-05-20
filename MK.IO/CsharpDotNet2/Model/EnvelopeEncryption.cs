// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.



using System.Text;
using System.Text.Json;

namespace MK.IO.Models
{

    /// <summary>
    /// 
    /// </summary>

    public class EnvelopeEncryption
    {
        /// <summary>
        /// Clear tracks. This is the set of tracks that will be delivered without envelope encryption.
        /// </summary>
        /// <value>Clear tracks. This is the set of tracks that will be delivered without envelope encryption.</value>
        public List<TrackSelection> ClearTracks { get; set; }

        /// <summary>
        /// Gets or Sets ContentKeys
        /// </summary>
        public StreamingPolicyContentKeys ContentKeys { get; set; }

        /// <summary>
        /// Optional template for the customer service to use for key acquisition. Not needed if using the built-in key delivery service.
        /// </summary>
        /// <value>Optional template for the customer service to use for key acquisition. Not needed if using the built-in key delivery service.</value>
        public string CustomKeyAcquisitionUrlTemplate { get; set; }

        /// <summary>
        /// Gets or Sets EnabledProtocols
        /// </summary>
        public EnabledProtocols EnabledProtocols { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class EnvelopeEncryption {\n");
            sb.Append("  ClearTracks: ").Append(ClearTracks).Append("\n");
            sb.Append("  ContentKeys: ").Append(ContentKeys).Append("\n");
            sb.Append("  CustomKeyAcquisitionUrlTemplate: ").Append(CustomKeyAcquisitionUrlTemplate).Append("\n");
            sb.Append("  EnabledProtocols: ").Append(EnabledProtocols).Append("\n");
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
