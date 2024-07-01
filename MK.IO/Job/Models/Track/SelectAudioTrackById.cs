// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Runtime.Serialization;
using Newtonsoft.Json;

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
        [JsonProperty(PropertyName = "@odata.type")]
        internal override string OdataType => "SelectAudioTrackById";

        /// <summary>
        /// Optional designation for single channel audio tracks.
        /// </summary>
        /// <value>Optional designation for single channel audio tracks.</value>
        [DataMember(Name = "channelMapping", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "channelMapping")]
        public AudioTrackChannelMappingType ChannelMapping { get; set; }

        /// <summary>
        /// Track identifier to select
        /// </summary>
        /// <value>Track identifier to select</value>
        [DataMember(Name = "trackId", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "trackId")]
        public int? TrackId { get; set; }
    }
}
