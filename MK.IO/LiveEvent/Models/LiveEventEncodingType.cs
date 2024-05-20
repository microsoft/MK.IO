// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace MK.IO.Models
{
    /// <summary>
    /// Live event type.
    /// When encodingType is set to PassthroughBasic or PassthroughStandard, the service simply passes through the incoming video and audio layer(s) to the output.
    /// When encodingType is set to Standard or Premium1080p, a live encoder transcodes the incoming stream into multiple bitrates or layers
    /// </summary>
    /// <value>Live event type. When encodingType is set to PassthroughBasic or PassthroughStandard, the service simply passes through the incoming video and audio layer(s) to the output. When encodingType is set to Standard or Premium1080p, a live encoder transcodes the incoming stream into multiple bitrates or layers</value>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum LiveEventEncodingType
    {
        /// <summary>
        /// Enum None for value: None
        /// </summary>
        None,

        /// <summary>
        /// Enum PassthroughBasic for value: PassthroughBasic
        /// </summary>
        PassthroughBasic,

        /// <summary>
        /// Enum PassthroughStandard for value: PassthroughStandard
        /// </summary>
        PassthroughStandard,

        /// <summary>
        /// Enum Premium1080p for value: Premium1080p
        /// </summary>
        Premium1080p,

        /// <summary>
        /// Enum Standard for value: Standard
        /// </summary>
        Standard
    }
}