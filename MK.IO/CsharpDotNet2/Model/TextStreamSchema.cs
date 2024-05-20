// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.



using System.Text;
using System.Text.Json;

namespace MK.IO.Models
{

    /// <summary>
    /// 
    /// </summary>

    public class TextStreamSchema
    {
        /// <summary>
        /// Gets or Sets Scheme
        /// </summary>
        public string Scheme { get; set; }

        /// <summary>
        /// Gets or Sets ManifestOutput
        /// </summary>
        public string ManifestOutput { get; set; }

        /// <summary>
        /// Gets or Sets ParentTrackName
        /// </summary>
        public string ParentTrackName { get; set; }

        /// <summary>
        /// Gets or Sets Src
        /// </summary>
        public string Src { get; set; }

        /// <summary>
        /// Gets or Sets SystemBitrate
        /// </summary>
        public string SystemBitrate { get; set; }

        /// <summary>
        /// Gets or Sets Timescale
        /// </summary>
        public string Timescale { get; set; }

        /// <summary>
        /// Gets or Sets TrackID
        /// </summary>
        public string TrackID { get; set; }

        /// <summary>
        /// Gets or Sets TrackName
        /// </summary>
        public string TrackName { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TextStreamSchema {\n");
            sb.Append("  Scheme: ").Append(Scheme).Append("\n");
            sb.Append("  ManifestOutput: ").Append(ManifestOutput).Append("\n");
            sb.Append("  ParentTrackName: ").Append(ParentTrackName).Append("\n");
            sb.Append("  Src: ").Append(Src).Append("\n");
            sb.Append("  SystemBitrate: ").Append(SystemBitrate).Append("\n");
            sb.Append("  Timescale: ").Append(Timescale).Append("\n");
            sb.Append("  TrackID: ").Append(TrackID).Append("\n");
            sb.Append("  TrackName: ").Append(TrackName).Append("\n");
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
