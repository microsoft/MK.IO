// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace MK.IO.Models
{
    /// <summary>
    /// The type of token.
    /// </summary>
    /// <value>The PlayReady license type.</value>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RestrictionTokenType
    {
        Unknown,

        Swt,

        Jwt
    }
}