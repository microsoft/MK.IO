// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace MK.IO.Models
{
    /// <summary>
    /// Live event type.
    /// When encodingType is set to PassthroughBasic or PassthroughStandard, the service simply passes through the incoming video and audio layer(s) to the output.
    /// When encodingType is set to Standard or Premium1080p, a live encoder transcodes the incoming stream into multiple bitrates or layers
    /// </summary>
    /// <value>Live event type. When encodingType is set to PassthroughBasic or PassthroughStandard, the service simply passes through the incoming video and audio layer(s) to the output. When encodingType is set to Standard or Premium1080p, a live encoder transcodes the incoming stream into multiple bitrates or layers</value>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum LiveEventEncodingType
    {
        /// <summary>
        /// Enum None for value: None
        /// </summary>
        [EnumMember(Value = "None")]
        None,

        /// <summary>
        /// Enum PassthroughBasic for value: PassthroughBasic
        /// </summary>
        [EnumMember(Value = "PassthroughBasic")]
        PassthroughBasic,

        /// <summary>
        /// Enum PassthroughStandard for value: PassthroughStandard
        /// </summary>
        [EnumMember(Value = "PassthroughStandard")]
        PassthroughStandard,

        /// <summary>
        /// Enum Premium1080p for value: Premium1080p
        /// </summary>
        [EnumMember(Value = "Premium1080p")]
        Premium1080p,

        /// <summary>
        /// Enum Standard for value: Standard
        /// </summary>
        [EnumMember(Value = "Standard")]
        Standard
    }
}