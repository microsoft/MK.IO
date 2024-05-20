// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace MK.IO.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AudioTrackChannelMappingType
    {
        /// <summary>
        /// Enum ChannelMappingType for value: BackLeft
        /// </summary>
        [EnumMember(Value = "BackLeft")]
        BackLeft,

        /// <summary>
        /// Enum ChannelMappingType for value: BackRight
        /// </summary>
        [EnumMember(Value = "BackRight")]
        BackRight,

        /// <summary>
        /// Enum ChannelMappingType for value: Center
        /// </summary>
        [EnumMember(Value = "Center")]
        Center,

        /// <summary>
        /// Enum ChannelMappingType for value: FrontLeft
        /// </summary>
        [EnumMember(Value = "FrontLeft")]
        FrontLeft,

        /// <summary>
        /// Enum ChannelMappingType for value: FrontRight
        /// </summary>
        [EnumMember(Value = "FrontRight")]
        FrontRight,

        /// <summary>
        /// Enum ChannelMappingType for value: LowFrequencyEffects
        /// </summary>
        [EnumMember(Value = "LowFrequencyEffects")]
        LowFrequencyEffects,

        /// <summary>
        /// Enum ChannelMappingType for value: StereoLeft
        /// </summary>
        [EnumMember(Value = "StereoLeft")]
        StereoLeft,

        /// <summary>
        /// Enum ChannelMappingType for value: StereoRight
        /// </summary>
        [EnumMember(Value = "StereoRight")]
        StereoRight
    }
}