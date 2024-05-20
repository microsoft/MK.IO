// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace MK.IO.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum FilterTrackPropertyType
    {
        /// <summary>
        /// Enum FilterTrackPropertyType for value: Unknown
        /// </summary>
        Unknown,

        /// <summary>
        /// Enum FilterTrackPropertyType for value: Type
        /// </summary>
        Type,

        /// <summary>
        /// Enum FilterTrackPropertyType for value: Name
        /// </summary>
        Name,

        /// <summary>
        /// Enum FilterTrackPropertyType for value: Language
        /// </summary>
        Language,

        /// <summary>
        /// Enum FilterTrackPropertyType for value: FourCC
        /// </summary>
        FourCC,

        /// <summary>
        /// Enum FilterTrackPropertyType for value: Bitrate
        /// </summary>
        Bitrate
    }
}