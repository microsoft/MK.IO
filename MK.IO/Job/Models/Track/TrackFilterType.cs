// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace MK.IO.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TrackFilterType
    {
        /// <summary>
        /// Enum AudioTrackFilterType for value: All
        /// </summary>
        All,

        /// <summary>
        /// Enum AudioTrackFilterType for value: Bottom
        /// </summary>
        Bottom,

        /// <summary>
        /// Enum AudioTrackFilterType for value: Top
        /// </summary>
        Top,

        /// <summary>
        /// Enum AudioTrackFilterType for value: ValueEquals
        /// </summary>
        ValueEquals
    }
}