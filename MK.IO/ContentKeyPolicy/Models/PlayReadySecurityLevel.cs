// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace MK.IO.Models
{
    /// <summary>
    /// The PlayReady security level.
    /// </summary>
    /// <value>The PlayReady security level.</value>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PlayReadySecurityLevel
    {
        Unknown,

        SL150,

        SL2000,

        SL3000
    }
}