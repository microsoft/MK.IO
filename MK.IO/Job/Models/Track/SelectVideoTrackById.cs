// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace MK.IO.Models
{
    /// <summary>
    /// 
    /// </summary>

    public class SelectVideoTrackById : TrackDiscriminator
    {
        public SelectVideoTrackById(int trackId)
        {
            TrackId = trackId;
        }

        /// <summary>
        /// The discriminator for derived types.
        /// </summary>
        /// <value>The discriminator for derived types.</value>
        [JsonPropertyName("@odata.type")]
        internal override string OdataType => "SelectVideoTrackById";

        /// <summary>
        /// Track identifier to select
        /// </summary>
        /// <value>Track identifier to select</value>
        public int? TrackId { get; set; }
    }
}
