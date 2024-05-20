// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace MK.IO.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TrackFilterType
    {
        /// <summary>
        /// Enum AudioTrackFilterType for value: All
        /// </summary>
        [EnumMember(Value = "All")]
        All,

        /// <summary>
        /// Enum AudioTrackFilterType for value: Bottom
        /// </summary>
        [EnumMember(Value = "Bottom")]
        Bottom,

        /// <summary>
        /// Enum AudioTrackFilterType for value: Top
        /// </summary>
        [EnumMember(Value = "Top")]
        Top,

        /// <summary>
        /// Enum AudioTrackFilterType for value: ValueEquals
        /// </summary>
        [EnumMember(Value = "ValueEquals")]
        ValueEquals
    }
}