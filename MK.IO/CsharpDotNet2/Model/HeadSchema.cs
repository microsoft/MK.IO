// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.



using System.Text;
using System.Text.Json;

namespace MK.IO.Models
{

    /// <summary>
    /// 
    /// </summary>

    public class HeadSchema
    {
        /// <summary>
        /// Gets or Sets AvailabilityStartTime
        /// </summary>
        public DateTime? AvailabilityStartTime { get; set; }

        /// <summary>
        /// Gets or Sets ClientManifestRelativePath
        /// </summary>
        public string ClientManifestRelativePath { get; set; }

        /// <summary>
        /// Gets or Sets CompatVersion
        /// </summary>
        public string CompatVersion { get; set; }

        /// <summary>
        /// Gets or Sets Extra
        /// </summary>
        public Dictionary<string, Object> Extra { get; set; }

        /// <summary>
        /// Gets or Sets Formats
        /// </summary>
        public string Formats { get; set; }

        /// <summary>
        /// Gets or Sets FragmentsPerHLSSegment
        /// </summary>
        public string FragmentsPerHLSSegment { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class HeadSchema {\n");
            sb.Append("  AvailabilityStartTime: ").Append(AvailabilityStartTime).Append("\n");
            sb.Append("  ClientManifestRelativePath: ").Append(ClientManifestRelativePath).Append("\n");
            sb.Append("  CompatVersion: ").Append(CompatVersion).Append("\n");
            sb.Append("  Extra: ").Append(Extra).Append("\n");
            sb.Append("  Formats: ").Append(Formats).Append("\n");
            sb.Append("  FragmentsPerHLSSegment: ").Append(FragmentsPerHLSSegment).Append("\n");
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
