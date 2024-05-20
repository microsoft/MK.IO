// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.



using System.Text;
using System.Text.Json;

namespace MK.IO.Models
{

    /// <summary>
    /// 
    /// </summary>

    public class StreamingLocatorListPathsResponseSchema
    {
        /// <summary>
        /// The download paths for the locator.
        /// </summary>
        /// <value>The download paths for the locator.</value>
        public List<string> DownloadPaths { get; set; }

        /// <summary>
        /// The license acquisition URLs for configured DRM types.
        /// </summary>
        /// <value>The license acquisition URLs for configured DRM types.</value>
        public Dictionary<string, StreamingLocatorDrm> Drm { get; set; }

        /// <summary>
        /// The streaming paths for the locator.
        /// </summary>
        /// <value>The streaming paths for the locator.</value>
        public List<StreamingLocatorListPathsStreamingPaths> StreamingPaths { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class StreamingLocatorListPathsResponseSchema {\n");
            sb.Append("  DownloadPaths: ").Append(DownloadPaths).Append("\n");
            sb.Append("  Drm: ").Append(Drm).Append("\n");
            sb.Append("  StreamingPaths: ").Append(StreamingPaths).Append("\n");
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
