

using System.Text;
using System.Text.Json;

namespace MK.IO.Models
{

    /// <summary>
    /// Class for CommonEncryptionCbcs encryption scheme
    /// </summary>

    public class CommonEncryptionCbcs
    {
        /// <summary>
        /// Gets or Sets ClearKeyEncryptionConfiguration
        /// </summary>
        public ClearKeyEncryptionConfiguration ClearKeyEncryptionConfiguration { get; set; }

        /// <summary>
        /// This represents which tracks should *not* be encrypted.
        /// </summary>
        /// <value>This represents which tracks should *not* be encrypted.</value>
        public List<TrackSelection> ClearTracks { get; set; }

        /// <summary>
        /// Gets or Sets ContentKeys
        /// </summary>
        public StreamingPolicyContentKeys ContentKeys { get; set; }

        /// <summary>
        /// Gets or Sets Drm
        /// </summary>
        public CbcsDrmConfiguration Drm { get; set; }

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
            sb.Append("class CommonEncryptionCbcs {\n");
            sb.Append("  ClearKeyEncryptionConfiguration: ").Append(ClearKeyEncryptionConfiguration).Append("\n");
            sb.Append("  ClearTracks: ").Append(ClearTracks).Append("\n");
            sb.Append("  ContentKeys: ").Append(ContentKeys).Append("\n");
            sb.Append("  Drm: ").Append(Drm).Append("\n");
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
