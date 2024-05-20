// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace MK.IO.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TrackAttributeType
    {
        /// <summary>
        /// Enum TrackAttributeType for value: Bitrate
        /// </summary>
        [EnumMember(Value = "Bitrate")]
        Bitrate,

        /// <summary>
        /// Enum TrackAttributeType for value: Language
        /// </summary>
        [EnumMember(Value = "Language")]
        Language
    }
}