// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace MK.IO.Models
{

    /// <summary>
    /// 
    /// </summary>
    public class SelectAudioTrackById : TrackDiscriminator
    {
        public SelectAudioTrackById(int trackId)
        {
            TrackId = trackId;
        }

        /// <summary>
        /// The discriminator for derived types.
        /// </summary>
        /// <value>The discriminator for derived types.</value>
        [JsonPropertyName("@odata.type")]
        internal override string OdataType => "SelectAudioTrackById";

        /// <summary>
        /// Optional designation for single channel audio tracks.
        /// </summary>
        /// <value>Optional designation for single channel audio tracks.</value>
        public AudioTrackChannelMappingType ChannelMapping { get; set; }

        /// <summary>
        /// Track indentifer to select
        /// </summary>
        /// <value>Track indentifer to select</value>
        public int? TrackId { get; set; }
    }
}
