// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace MK.IO.Models
{
    /// <summary>
    /// Track property type
    /// </summary>
    /// <value>Track property type</value>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TrackPropertyConditionPropertyType
    {
        Unknown,

        FourCC
    }
}