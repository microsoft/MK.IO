// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace MK.IO.Models
{
    /// <summary> The built-in preset to be used for converting videos. </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ConverterNamedPreset
    {
        /// <summary>
        /// Copy all video and audio streams from the input asset as non-interleaved video and audio output files
        /// </summary>
        [EnumMember(Value = "CopyAllBitrateNonInterleaved")]
        CopyAllBitrateNonInterleaved,

        /// <summary>
        /// Copy all video and audio streams from the input asset as interleaved video and audio output files
        /// </summary>
        [EnumMember(Value = "CopyAllBitrateInterleaved")]
        CopyAllBitrateInterleaved,

        /// <summary>
        /// Copy the top bitrate video along with all audio interleaved
        /// </summary>
        [EnumMember(Value = "CopyTopBitrateInterleaved")]
        CopyTopBitrateInterleaved
    }
}