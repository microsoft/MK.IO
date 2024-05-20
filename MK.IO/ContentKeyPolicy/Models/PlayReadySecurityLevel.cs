// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace MK.IO.Models
{
    /// <summary>
    /// The PlayReady security level.
    /// </summary>
    /// <value>The PlayReady security level.</value>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PlayReadySecurityLevel
    {
        [EnumMember(Value = "Unknown")]
        Unknown,

        [EnumMember(Value = "SL150")]
        SL150,

        [EnumMember(Value = "SL2000")]
        SL2000,

        [EnumMember(Value = "SL3000")]
        SL3000,
    }
}