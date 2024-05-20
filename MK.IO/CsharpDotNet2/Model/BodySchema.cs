// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.



using System.Text;
using System.Text.Json;

namespace MK.IO.Models
{

    /// <summary>
    /// 
    /// </summary>

    public class BodySchema
    {
        /// <summary>
        /// Gets or Sets Audio
        /// </summary>
        public List<AudioSchema> Audio { get; set; }

        /// <summary>
        /// Gets or Sets Textstream
        /// </summary>
        public List<TextStreamSchema> Textstream { get; set; }

        /// <summary>
        /// Gets or Sets Video
        /// </summary>
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
            return JsonSerializer.Serialize(this, ConverterLE.Settings);
        }

    }
}
