// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace MK.IO.Models
{
    /// <summary>
    /// The input protocol for the live event.
    /// This is specified at creation time and cannot be updated.
    /// </summary>
    /// <value>Must be one of RTMP or SRT. fmp4 smooth input is not supported.</value>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum LiveEventInputProtocol
    {
        /// <summary>
        /// Enum RTMP for value: RTMP
        /// </summary>
        RTMP,

        /// <summary>
        /// Enum SRT for value: SRT
        /// </summary>
        SRT
    }
}