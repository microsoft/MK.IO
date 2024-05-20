// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace MK.IO.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum FilterTrackPropertyType
    {
        /// <summary>
        /// Enum FilterTrackPropertyType for value: Unknown
        /// </summary>
        [EnumMember(Value = "Unknown")]
        Unknown,

        /// <summary>
        /// Enum FilterTrackPropertyType for value: Type
        /// </summary>
        [EnumMember(Value = "Type")]
        Type,

        /// <summary>
        /// Enum FilterTrackPropertyType for value: Name
        /// </summary>
        [EnumMember(Value = "Name")]
        Name,

        /// <summary>
        /// Enum FilterTrackPropertyType for value: Language
        /// </summary>
        [EnumMember(Value = "Language")]
        Language,

        /// <summary>
        /// Enum FilterTrackPropertyType for value: FourCC
        /// </summary>
        [EnumMember(Value = "FourCC")]
        FourCC,

        /// <summary>
        /// Enum FilterTrackPropertyType for value: Bitrate
        /// </summary>
        [EnumMember(Value = "Bitrate")]
        Bitrate
    }
}