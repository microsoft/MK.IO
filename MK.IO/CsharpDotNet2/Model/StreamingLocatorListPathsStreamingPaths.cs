// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.



using System.Text;
using System.Text.Json;

namespace MK.IO.Models
{

    /// <summary>
    /// 
    /// </summary>

    public class StreamingLocatorListPathsStreamingPaths
    {
        /// <summary>
        /// The encryption scheme used for the path.
        /// </summary>
        /// <value>The encryption scheme used for the path.</value>
        public StreamingPathsEncryptionScheme EncryptionScheme { get; set; }

        /// <summary>
        /// The paths for the locator.
        /// </summary>
        /// <value>The paths for the locator.</value>
        public List<string> Paths { get; set; }

        /// <summary>
        /// The streaming protocol used for the path.
        /// </summary>
        /// <value>The streaming protocol used for the path.</value>
        public StreamingPathsStreamingProtocol StreamingProtocol { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class StreamingLocatorListPathsStreamingPaths {\n");
            sb.Append("  EncryptionScheme: ").Append(EncryptionScheme).Append("\n");
            sb.Append("  Paths: ").Append(Paths).Append("\n");
            sb.Append("  StreamingProtocol: ").Append(StreamingProtocol).Append("\n");
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
