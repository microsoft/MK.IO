// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace MK.IO.Models
{
    /// <summary>
    /// Track property operation. Only equality is supported.
    /// </summary>
    /// <value>Track property operation. Only equality is supported.</value>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TrackPropertyConditionOperationType
    {
        [EnumMember(Value = "Unknown")]
        Unknown,

        [EnumMember(Value = "Equal")]
        Equal
    }
}