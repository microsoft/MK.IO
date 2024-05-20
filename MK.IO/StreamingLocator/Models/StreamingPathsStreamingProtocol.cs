// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace MK.IO.Models
{
    /// <summary>
    /// The streaming protocol used for the path.
    /// </summary>
    /// <value>The streaming protocol used for the path.</value>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum StreamingPathsStreamingProtocol
    {
        [EnumMember(Value = "Hls")]
        Hls,

        [EnumMember(Value = "Dash")]
        Dash,

        [EnumMember(Value = "Download")]
        Download,

        [EnumMember(Value = "SmoothStreaming")]
        SmoothStreaming,
    }
}