// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.



using System.Text;
using System.Text.Json;

namespace MK.IO.Models
{

    /// <summary>
    /// 
    /// </summary>

    public class TrackSelection
    {
        /// <summary>
        /// track selections is used to specify a set or a subset of track for selection by the streaming policy.
        /// </summary>
        /// <value>track selections is used to specify a set or a subset of track for selection by the streaming policy.</value>
        public List<TrackPropertyCondition> TrackSelections { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TrackSelection {\n");
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
