// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace MK.IO.Models
{

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class MediaFilterProperties
    {
        /// <summary>
        /// Gets or Sets FirstQuality
        /// </summary>
        [DataMember(Name = "firstQuality", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "firstQuality")]
        public FirstQuality FirstQuality { get; set; }

        /// <summary>
        /// Gets or Sets PresentationTimeRange
        /// </summary>
        [DataMember(Name = "presentationTimeRange", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "presentationTimeRange")]
        public PresentationTimeRange PresentationTimeRange { get; set; }

        /// <summary>
        /// Defines the tracks to include in the output. If multiple FilterTrackSelection objects are provided, their configurations will be OR'd together.                  For instance, if you want to include all audio tracks that are not English, and all video tracks that are between 3 and 5 Mbps, you would provide two FilterTrackSelection objects.         
        /// </summary>
        /// <value>Defines the tracks to include in the output. If multiple FilterTrackSelection objects are provided, their configurations will be OR'd together.                  For instance, if you want to include all audio tracks that are not English, and all video tracks that are between 3 and 5 Mbps, you would provide two FilterTrackSelection objects.         </value>
        [DataMember(Name = "tracks", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "tracks")]
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
            return JsonConvert.SerializeObject(this, ConverterLE.Settings);
        }

    }
}
