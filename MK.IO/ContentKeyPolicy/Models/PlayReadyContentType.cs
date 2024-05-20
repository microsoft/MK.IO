// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace MK.IO.Models
{
    /// <summary>
    /// The PlayReady content type.
    /// </summary>
    /// <value>The PlayReady content type.</value>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PlayReadyContentType
    {
        [EnumMember(Value = "Unknown")]
        Unknown,

        [EnumMember(Value = "Unspecified")]
        Unspecified,

        [EnumMember(Value = "UltraVioletDownload")]
        UltraVioletDownload,

        [EnumMember(Value = "UltraVioletStreaming")]
        UltraVioletStreaming,
    }
}