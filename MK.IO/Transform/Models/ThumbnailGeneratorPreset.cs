// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;
using System.Text;

namespace MK.IO.Models
{
    public class ThumbnailGeneratorPreset : TransformPreset
    {
        /// <summary>
        /// Constructor for ThumbnailGeneratorPreset
        /// </summary>
        /// <param name="thumbnails">The set of thumbnails to be produced.</param>
        /// <param name="baseFileName">Used to create the output filename as `{BaseFilename}_{Label}{Index}{Extension}`.  The default is the name of the input file.  If the name of the input file is too long then it will be truncated to 64 characters.</param>
        public ThumbnailGeneratorPreset(List<ThumbnailGeneratorConfiguration> thumbnails, string? baseFileName = null)
        {
            Argument.AssertNotMoreThanLength(baseFileName, nameof(baseFileName), 64);
            Argument.AssertRespectRegex(baseFileName, nameof(baseFileName), @"^[A-Za-z0-9_-]+$");

            BaseFilename = baseFileName;
            Thumbnails = thumbnails;
        }

        [JsonProperty("@odata.type")]
        internal override string OdataType => "#MediaKind.ThumbnailGeneratorPreset";

        /// <summary>
        /// Used to create the output filename as `{BaseFilename}_{Label}{Index}{Extension}`.  The default is the name of the input file.  If the name of the input file is too long then it will be truncated to 64 characters.
        /// </summary>
        /// <value>Used to create the output filename as `{BaseFilename}_{Label}{Index}{Extension}`.  The default is the name of the input file.  If the name of the input file is too long then it will be truncated to 64 characters.</value>
        [JsonProperty("baseFilename")]
        public string? BaseFilename { get; set; }

        /// <summary>
        /// The set of thumbnails to be produced.
        /// </summary>
        /// <value>The set of thumbnails to be produced.</value>
        [JsonProperty("thumbnails")]
        public List<ThumbnailGeneratorConfiguration> Thumbnails { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ThumbnailGeneratorPreset {\n");
            sb.Append("  OdataType: ").Append(OdataType).Append("\n");
            sb.Append("  BaseFilename: ").Append(BaseFilename).Append("\n");
            sb.Append("  Thumbnails: ").Append(Thumbnails).Append("\n");
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