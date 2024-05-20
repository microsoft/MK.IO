// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace MK.IO.Models
{

    /// <summary>
    /// 
    /// </summary>

    public class FromAllInputFile : InputFileDiscriminator
    {
        public FromAllInputFile(List<TrackDiscriminator> includedTracks)
        {
            IncludedTracks = includedTracks;
        }

        /// <summary>
        /// The discriminator for derived types.
        /// </summary>
        /// <value>The discriminator for derived types.</value>
        [JsonPropertyName("@odata.type")]
        internal override string OdataType => "#Microsoft.Media.JobInputAsset";

        /// <summary>
        /// The list of TrackDescriptors which define the metadata and selection of tracks in the input.
        /// </summary>
        /// <value>The list of TrackDescriptors which define the metadata and selection of tracks in the input.</value>
        public List<TrackDiscriminator> IncludedTracks { get; set; }
    }
}
