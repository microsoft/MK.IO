// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace MK.IO.Models
{
    /// <summary>
    /// The streaming protocol used for the path.
    /// </summary>
    /// <value>The streaming protocol used for the path.</value>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StreamingPathsStreamingProtocol
    {
        Hls,

        Dash,

        Download,

        SmoothStreaming
    }
}