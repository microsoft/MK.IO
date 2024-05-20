// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace MK.IO.Models
{
    /// <summary>
    /// The type of token.
    /// </summary>
    /// <value>The PlayReady license type.</value>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum RestrictionTokenType
    {
        [EnumMember(Value = "Unknown")]
        Unknown,

        [EnumMember(Value = "Swt")]
        Swt,

        [EnumMember(Value = "Jwt")]
        Jwt,
    }
}