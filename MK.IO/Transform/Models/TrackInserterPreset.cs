// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace MK.IO.Models
{
    public class TrackInserterPreset : TransformPreset
    {
        /// <summary>
        /// Constructor for TrackInserterPreset
        /// </summary>
        /// <param name="tracks">The set of tracks to be inserted.  Currently limited to one.</param>
        /// <param name="baseFileName">Used to create the output filename as `{BaseFilename}.cmft`.  The default is the name of the input .vtt file minus the extension, e.g. `subtitles.vtt` -> `subtitles.cmft`.</param>
        public TrackInserterPreset(List<TrackInserter> tracks, string baseFileName = null)
        {
            Argument.AssertNotMoreThanLength(baseFileName, nameof(baseFileName), 64);
            Argument.AssertRespectRegex(baseFileName, nameof(baseFileName), @"^[A-Za-z0-9_-]+$");
            if (tracks.Count != 1)
            {
                throw new ArgumentException("tracks parameter can only have one track.");
            }

            BaseFilename = baseFileName;
            Tracks = tracks;
        }

        [JsonProperty("@odata.type")]
        internal override string OdataType => "#MediaKind.TrackInserterPreset";

        /// <summary>
        /// Used to create the output filename as `{BaseFilename}.cmft`.  The default is the name of the input .vtt file minus the extension, e.g. `subtitles.vtt` -> `subtitles.cmft`.
        /// </summary>
        /// <value>Used to create the output filename as `{BaseFilename}.cmft`.  The default is the name of the input .vtt file minus the extension, e.g. `subtitles.vtt` -> `subtitles.cmft`.</value>
        [DataMember(Name = "baseFilename", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "baseFilename")]
        public string BaseFilename { get; set; }

        /// <summary>
        /// The set of tracks to be inserted.  Currently limited to one.
        /// </summary>
        /// <value>The set of tracks to be inserted.  Currently limited to one.</value>
        [DataMember(Name = "tracks", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "tracks")]
        public List<TrackInserter> Tracks { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TrackInserterPreset {\n");
            sb.Append("  OdataType: ").Append(OdataType).Append("\n");
            sb.Append("  BaseFilename: ").Append(BaseFilename).Append("\n");
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