// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace MK.IO.Models
{

    /// <summary>
    /// 
    /// </summary>

    public class AudioTrackDescriptor : TrackDiscriminator
    {
        /// <summary>
        /// The discriminator for derived types.
        /// </summary>
        /// <value>The discriminator for derived types.</value>
        [JsonPropertyName("@odata.type")]
        internal override string OdataType => "AudioTrackDescriptor";

        /// <summary>
        /// Optional designation for single channel audio tracks.
        /// </summary>
        /// <value>Optional designation for single channel audio tracks.</value>
        public string ChannelMapping { get; set; }
    }
}
