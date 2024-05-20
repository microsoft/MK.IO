// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace MK.IO.Models
{
    /// <summary>
    /// Track property operation. Only equality is supported.
    /// </summary>
    /// <value>Track property operation. Only equality is supported.</value>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TrackPropertyConditionOperationType
    {
        Unknown,

        Equal
    }
}