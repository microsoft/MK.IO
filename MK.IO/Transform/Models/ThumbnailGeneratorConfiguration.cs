// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;
using System.Text;

namespace MK.IO.Models
{

    /// <summary>
    /// 
    /// </summary>
    public class ThumbnailGeneratorConfiguration
    {
        /// <summary>
        /// The output format for the thumbnails.
        /// </summary>
        /// <value>The output format for the thumbnails.</value>
        [JsonProperty(PropertyName = "format")]
        public string Format { get; set; }

        /// <summary>
        /// Either an integer size in pixels, or a percentage of the input resolution. If either width/height is defined as percentage, the other dimension must be the same percentage.
        /// </summary>
        /// <value>Either an integer size in pixels, or a percentage of the input resolution. If either width/height is defined as percentage, the other dimension must be the same percentage.</value>
        [JsonProperty(PropertyName = "height")]
        public string Height { get; set; }

        /// <summary>
        /// Used to create the output filename as `{BaseFilename}_{Label}{Index}{Extension}`. When generating sprites, the output vtt file will be named `{BaseFilename}_{Label}.vtt`
        /// </summary>
        /// <value>Used to create the output filename as `{BaseFilename}_{Label}{Index}{Extension}`. When generating sprites, the output vtt file will be named `{BaseFilename}_{Label}.vtt`</value>
        [JsonProperty(PropertyName = "label")]
        public string Label { get; set; }

        /// <summary>
        /// The compression quality for JPEG images.  Between 0-100, default: 70.
        /// </summary>
        /// <value>The compression quality for JPEG images.  Between 0-100, default: 70.</value>
        [JsonProperty(PropertyName = "quality")]
        public int? Quality { get; set; } = 70;

        /// <summary>
        /// Either an ISO8601 duration, or a percentage of the asset duration, or the value '1'.  The default is '1', a single thumbnail is produced.
        /// </summary>
        /// <value>Either an ISO8601 duration, or a percentage of the asset duration, or the value '1'.  The default is '1', a single thumbnail is produced.</value>
        [JsonProperty(PropertyName = "range")]
        public string Range { get; set; } = "1";

        /// <summary>
        /// The number of columns used if you want a thumbnail sprite image.  Default: Single image output files.
        /// </summary>
        /// <value>The number of columns used if you want a thumbnail sprite image.  Default: Single image output files.</value>
        [JsonProperty(PropertyName = "spriteColumn")]
        public int? SpriteColumn { get; set; }

        /// <summary>
        /// Either an ISO8601 duration, or a percentage of the asset duration.  Default: PT10S.
        /// </summary>
        /// <value>Either an ISO8601 duration, or a percentage of the asset duration.  Default: PT10S.</value>
        [JsonProperty(PropertyName = "start")]
        public string Start { get; set; } = "PT10S";

        /// <summary>
        /// The intervals at which thumbnails are generated. Either an ISO8601 duration, or a percentage of the asset duration.
        /// </summary>
        /// <value>The intervals at which thumbnails are generated. Either an ISO8601 duration, or a percentage of the asset duration.</value>
        [JsonProperty(PropertyName = "step")]
        public string Step { get; set; } = "10%";

        /// <summary>
        /// Either an integer size in pixels, or a percentage of the input resolution. If only one of width/height is present, the aspect ratio from the source is preserved.
        /// </summary>
        /// <value>Either an integer size in pixels, or a percentage of the input resolution. If only one of width/height is present, the aspect ratio from the source is preserved.</value>
        [JsonProperty(PropertyName = "width")]
        public string Width { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ThumbnailGeneratorConfiguration {\n");
            sb.Append("  Format: ").Append(Format).Append("\n");
            sb.Append("  Height: ").Append(Height).Append("\n");
            sb.Append("  Label: ").Append(Label).Append("\n");
            sb.Append("  Quality: ").Append(Quality).Append("\n");
            sb.Append("  Range: ").Append(Range).Append("\n");
            sb.Append("  SpriteColumn: ").Append(SpriteColumn).Append("\n");
            sb.Append("  Start: ").Append(Start).Append("\n");
            sb.Append("  Step: ").Append(Step).Append("\n");
            sb.Append("  Width: ").Append(Width).Append("\n");
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
