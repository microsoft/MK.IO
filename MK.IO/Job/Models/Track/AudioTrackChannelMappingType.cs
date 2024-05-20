// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace MK.IO.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum AudioTrackChannelMappingType
    {
        /// <summary>
        /// Enum ChannelMappingType for value: BackLeft
        /// </summary>
        BackLeft,

        /// <summary>
        /// Enum ChannelMappingType for value: BackRight
        /// </summary>
        BackRight,

        /// <summary>
        /// Enum ChannelMappingType for value: Center
        /// </summary>
        Center,

        /// <summary>
        /// Enum ChannelMappingType for value: FrontLeft
        /// </summary>
        FrontLeft,

        /// <summary>
        /// Enum ChannelMappingType for value: FrontRight
        /// </summary>
        FrontRight,

        /// <summary>
        /// Enum ChannelMappingType for value: LowFrequencyEffects
        /// </summary>
        LowFrequencyEffects,

        /// <summary>
        /// Enum ChannelMappingType for value: StereoLeft
        /// </summary>
        StereoLeft,

        /// <summary>
        /// Enum ChannelMappingType for value: StereoRight
        /// </summary>
        StereoRight
    }
}