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
    public class BodySchema
    {
        /// <summary>
        /// Gets or Sets Audio
        /// </summary>
        [DataMember(Name = "audio", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "audio")]
        public List<AudioSchema> Audio { get; set; }

        /// <summary>
        /// Gets or Sets Textstream
        /// </summary>
        [DataMember(Name = "textstream", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "textstream")]
        public List<TextStreamSchema> Textstream { get; set; }

        /// <summary>
        /// Gets or Sets Video
        /// </summary>
        [DataMember(Name = "video", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "video")]
        public List<VideoSchema> Video { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class BodySchema {\n");
            sb.Append("  Audio: ").Append(Audio).Append("\n");
            sb.Append("  Textstream: ").Append(Textstream).Append("\n");
            sb.Append("  Video: ").Append(Video).Append("\n");
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
