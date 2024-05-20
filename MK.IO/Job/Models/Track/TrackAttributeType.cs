// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace MK.IO.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TrackAttributeType
    {
        /// <summary>
        /// Enum TrackAttributeType for value: Bitrate
        /// </summary>
        Bitrate,

        /// <summary>
        /// Enum TrackAttributeType for value: Language
        /// </summary>
        Language
    }
}