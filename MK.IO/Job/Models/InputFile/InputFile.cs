// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace MK.IO.Models
{

    /// <summary>
    /// 
    /// </summary>

    public class InputFile : InputFileDiscriminator
    {
        public InputFile(string filename, List<TrackDiscriminator> includedTracks)
        {
            Filename = filename;
            IncludedTracks = includedTracks;
        }

        /// <summary>
        /// The discriminator for derived types.
        /// </summary>
        /// <value>The discriminator for derived types.</value>
        [JsonPropertyName("@odata.type")]
        internal override string OdataType => "InputFile";

        /// <summary>
        /// Name of the file that this input definition applies to.
        /// </summary>
        /// <value>Name of the file that this input definition applies to.</value>
        public string Filename { get; set; }

        /// <summary>
        /// The list of TrackDescriptors which define the metadata and selection of tracks in the input.
        /// </summary>
        /// <value>The list of TrackDescriptors which define the metadata and selection of tracks in the input.</value>
        public List<TrackDiscriminator> IncludedTracks { get; set; }
    }
}
