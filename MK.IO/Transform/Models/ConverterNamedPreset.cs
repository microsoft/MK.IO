// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace MK.IO.Models
{
    /// <summary> The built-in preset to be used for converting videos. </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ConverterNamedPreset
    {
        /// <summary>
        /// Copy all video and audio streams from the input asset as non-interleaved video and audio output files
        /// </summary>
        [EnumMember(Value = "CopyAllBitrateNonInterleaved")]
        CopyAllBitrateNonInterleaved,

        /// <summary>
        /// Copy the top bitrate video along with all audio interleaved
        /// </summary>
        [EnumMember(Value = "CopyTopBitrateInterleaved")]
        CopyTopBitrateInterleaved
    }
}