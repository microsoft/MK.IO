// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.



using System.Text;
using System.Text.Json;

namespace MK.IO.Models
{

    /// <summary>
    /// 
    /// </summary>

    public class MediaFilterProperties
    {
        /// <summary>
        /// Gets or Sets FirstQuality
        /// </summary>
        public FirstQuality FirstQuality { get; set; }

        /// <summary>
        /// Gets or Sets PresentationTimeRange
        /// </summary>
        public PresentationTimeRange PresentationTimeRange { get; set; }

        /// <summary>
        /// Defines the tracks to include in the output. If multiple FilterTrackSelection objects are provided, their configurations will be OR'd together.                  For instance, if you want to include all audio tracks that are not English, and all video tracks that are between 3 and 5 Mbps, you would provide two FilterTrackSelection objects.         
        /// </summary>
        /// <value>Defines the tracks to include in the output. If multiple FilterTrackSelection objects are provided, their configurations will be OR'd together.                  For instance, if you want to include all audio tracks that are not English, and all video tracks that are between 3 and 5 Mbps, you would provide two FilterTrackSelection objects.         </value>
        public List<FilterTrackSelection> Tracks { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class MediaFilterProperties {\n");
            sb.Append("  FirstQuality: ").Append(FirstQuality).Append("\n");
            sb.Append("  PresentationTimeRange: ").Append(PresentationTimeRange).Append("\n");
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
