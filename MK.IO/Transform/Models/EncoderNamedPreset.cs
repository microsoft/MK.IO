// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace MK.IO.Models
{
    /// <summary> The built-in preset to be used for encoding videos. </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EncoderNamedPreset
    {
        /// <summary>
        /// Enum H264SingleBitrateSD for value: H264SingleBitrateSD
        /// </summary>
        [EnumMember(Value = "H264SingleBitrateSD")]
        H264SingleBitrateSD,

        /// <summary>
        /// Enum H264SingleBitrate720p for value: H264SingleBitrate720p
        /// </summary>
        [EnumMember(Value = "H264SingleBitrate720p")]
        H264SingleBitrate720p,

        /// <summary>
        /// Enum H264SingleBitrate1080p for value: H264SingleBitrate1080p
        /// </summary>
        [EnumMember(Value = "H264SingleBitrate1080p")]
        H264SingleBitrate1080p,

        /// <summary>
        /// Enum H264MultipleBitrateSD for value: H264MultipleBitrateSD
        /// </summary>
        [EnumMember(Value = "H264MultipleBitrateSD")]
        H264MultipleBitrateSD,

        /// <summary>
        /// Enum H264MultipleBitrate720p for value: H264MultipleBitrate720p
        /// </summary>
        [EnumMember(Value = "H264MultipleBitrate720p")]
        H264MultipleBitrate720p,

        /// <summary>
        /// Enum H264MultipleBitrate1080p for value: H264MultipleBitrate1080p
        /// </summary>
        [EnumMember(Value = "H264MultipleBitrate1080p")]
        H264MultipleBitrate1080p,

        /// <summary>
        /// Enum H264MultipleBitrateSDWithCVQ for value: H264MultipleBitrateSDWithCVQ
        /// </summary>
        [EnumMember(Value = "H264MultipleBitrateSDWithCVQ")]
        H264MultipleBitrateSDWithCVQ,

        /// <summary>
        /// Enum H264MultipleBitrate720pWithCVQ for value: H264MultipleBitrate720pWithCVQ
        /// </summary>
        [EnumMember(Value = "H264MultipleBitrate720pWithCVQ")]
        H264MultipleBitrate720pWithCVQ,

        /// <summary>
        /// Enum H264MultipleBitrate1080pWithCVQ for value: H264MultipleBitrate1080pWithCVQ
        /// </summary>
        [EnumMember(Value = "H264MultipleBitrate1080pWithCVQ")]
        H264MultipleBitrate1080pWithCVQ,

        /// <summary>
        /// Enum H265SingleBitrate720p for value: H265SingleBitrate720p
        /// </summary>
        [EnumMember(Value = "H265SingleBitrate720p")]
        H265SingleBitrate720p,

        /// <summary>
        /// Enum H265SingleBitrate1080p for value: H265SingleBitrate1080p
        /// </summary>
        [EnumMember(Value = "H265SingleBitrate1080p")]
        H265SingleBitrate1080p,

        /// <summary>
        /// Enum H265SingleBitrate4K for value: H265SingleBitrate4K
        /// </summary>
        [EnumMember(Value = "H265SingleBitrate4K")]
        H265SingleBitrate4K,

        /// <summary>
        /// Enum AACGoodQualityAudio for value: AACGoodQualityAudio
        /// </summary>
        [EnumMember(Value = "AACGoodQualityAudio")]
        AACGoodQualityAudio
    }
}