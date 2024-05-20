// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace MK.IO.Models
{
    /// <summary>
    /// The input protocol for the live event.
    /// This is specified at creation time and cannot be updated.
    /// </summary>
    /// <value>Must be one of RTMP or SRT. fmp4 smooth input is not supported.</value>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum LiveEventInputProtocol
    {
        /// <summary>
        /// Enum RTMP for value: RTMP
        /// </summary>
        [EnumMember(Value = "RTMP")]
        RTMP,

        /// <summary>
        /// Enum SRT for value: SRT
        /// </summary>
        [EnumMember(Value = "SRT")]
        SRT
    }
}