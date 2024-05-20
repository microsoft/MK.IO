// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.



using System.Text;
using System.Text.Json;

namespace MK.IO.Models
{

    /// <summary>
    /// 
    /// </summary>

    public class AudioSchema
    {
        /// <summary>
        /// Gets or Sets Src
        /// </summary>
        public string Src { get; set; }

        /// <summary>
        /// Gets or Sets SystemBitrate
        /// </summary>
        public string SystemBitrate { get; set; }

        /// <summary>
        /// Gets or Sets SystemLanguage
        /// </summary>
        public string SystemLanguage { get; set; }

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
            sb.Append("class AudioSchema {\n");
            sb.Append("  Src: ").Append(Src).Append("\n");
            sb.Append("  SystemBitrate: ").Append(SystemBitrate).Append("\n");
            sb.Append("  SystemLanguage: ").Append(SystemLanguage).Append("\n");
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
