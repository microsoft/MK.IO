// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace MK.IO.Models
{
    /// <summary>
    /// Track property type
    /// </summary>
    /// <value>Track property type</value>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TrackPropertyConditionPropertyType
    {
        [EnumMember(Value = "Unknown")]
        Unknown,

        [EnumMember(Value = "FourCC")]
        FourCC
    }
}