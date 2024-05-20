// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.



using System.Text;
using System.Text.Json;

namespace MK.IO.Models
{

    /// <summary>
    /// 
    /// </summary>

    public class FilterTrackSelection
    {
        /// <summary>
        /// Defines the tracks to include in the output. Multiple entries here will be AND'd together.                  Typically, you will want to select a matching Type, such as video, and then select additional filters.          For instance, to include all audio tracks that are not English, and all video tracks that are between 3 and 5 Mbps, you would provide three FilterTrackSelection objects:         [             {\"property\": \"Type\", \"operation\": \"Equal\", \"value\": \"Audio\"},             {\"property\": \"Bitrate\", \"operation\": \"Equal\", \"value\": \"3000000-5000000\"},             {\"property\": \"Language\", \"operation\": \"NotEqual\", \"value\": \"en\"},         ]         
        /// </summary>
        /// <value>Defines the tracks to include in the output. Multiple entries here will be AND'd together.                  Typically, you will want to select a matching Type, such as video, and then select additional filters.          For instance, to include all audio tracks that are not English, and all video tracks that are between 3 and 5 Mbps, you would provide three FilterTrackSelection objects:         [             {\"property\": \"Type\", \"operation\": \"Equal\", \"value\": \"Audio\"},             {\"property\": \"Bitrate\", \"operation\": \"Equal\", \"value\": \"3000000-5000000\"},             {\"property\": \"Language\", \"operation\": \"NotEqual\", \"value\": \"en\"},         ]         </value>
        public List<FilterTrackPropertyCondition> TrackSelections { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class FilterTrackSelection {\n");
            sb.Append("  TrackSelections: ").Append(TrackSelections).Append("\n");
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
