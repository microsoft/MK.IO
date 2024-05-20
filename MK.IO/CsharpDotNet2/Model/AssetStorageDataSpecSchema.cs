// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.



using System.Text;
using System.Text.Json;

namespace MK.IO.Models
{

    /// <summary>
    /// 
    /// </summary>

    public class AssetStorageDataSpecSchema
    {
        /// <summary>
        /// The name of the storage container.
        /// </summary>
        /// <value>The name of the storage container.</value>
        public string Container { get; set; }

        /// <summary>
        /// A dictionary containing error information. This field will be populated in cases where no valid tracks are present.
        /// </summary>
        /// <value>A dictionary containing error information. This field will be populated in cases where no valid tracks are present.</value>
        public Dictionary<string, string> Error { get; set; }

        /// <summary>
        /// Gets or Sets Exceptions
        /// </summary>
        public ExceptionsSchema Exceptions { get; set; }

        /// <summary>
        /// A list of files in the storage container. This only represents files present at the top-level of the container.
        /// </summary>
        /// <value>A list of files in the storage container. This only represents files present at the top-level of the container.</value>
        public List<FileSchema> Files { get; set; }

        /// <summary>
        /// A list of folders in the storage container.
        /// </summary>
        /// <value>A list of folders in the storage container.</value>
        public List<FolderSchema> Folders { get; set; }

        /// <summary>
        /// A hint to the client as to the format of the data.          mk.mezz.v0 is MediaKind's mezzanine format and will emit a period element.          ams.v0 is Azure Media Services' format and will emit a tracks element.
        /// </summary>
        /// <value>A hint to the client as to the format of the data.          mk.mezz.v0 is MediaKind's mezzanine format and will emit a period element.          ams.v0 is Azure Media Services' format and will emit a tracks element.</value>
        public string FormatHint { get; set; }

        /// <summary>
        /// A map of available content for each eligible file in the storage container. Typically just '0/index/edge'.         Periods are extracted from the latest instance of the MediaKind mezzanine representation format available in the container.         Tracks or Periods will be available, but not both.         
        /// </summary>
        /// <value>A map of available content for each eligible file in the storage container. Typically just '0/index/edge'.         Periods are extracted from the latest instance of the MediaKind mezzanine representation format available in the container.         Tracks or Periods will be available, but not both.         </value>
        public Dictionary<string, Period> Periods { get; set; }

        /// <summary>
        /// A map of available content for each eligible file in the storage container.         Tracks are extracted from all eligible files within the container and are presented to the client with the filename as the dictionary key.         Tracks or Periods will be available, but not both.         
        /// </summary>
        /// <value>A map of available content for each eligible file in the storage container.         Tracks are extracted from all eligible files within the container and are presented to the client with the filename as the dictionary key.         Tracks or Periods will be available, but not both.         </value>
        public Dictionary<string, TrackSchema> Tracks { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AssetStorageDataSpecSchema {\n");
            sb.Append("  Container: ").Append(Container).Append("\n");
            sb.Append("  Error: ").Append(Error).Append("\n");
            sb.Append("  Exceptions: ").Append(Exceptions).Append("\n");
            sb.Append("  Files: ").Append(Files).Append("\n");
            sb.Append("  Folders: ").Append(Folders).Append("\n");
            sb.Append("  FormatHint: ").Append(FormatHint).Append("\n");
            sb.Append("  Periods: ").Append(Periods).Append("\n");
            sb.Append("  Tracks: ").Append(Tracks).Append("\n");
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
