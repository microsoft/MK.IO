// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace MK.IO.Models
{
    /// <summary> The built-in preset to be used for encoding videos. </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EncoderNamedPreset
    {
        /// <summary>
        /// Outputs single MP4 file containing only stereo audio encoded at 192 kbps
        /// </summary>
        [EnumMember(Value = "AACGoodQualityAudio")]
        AACGoodQualityAudio,

        /// <summary>
        /// Outputs H.264 video (2200 kbps, 480p) and AAC stereo audio (128 kbps)
        /// </summary>
        [EnumMember(Value = "H264SingleBitrateSD")]
        H264SingleBitrateSD,

        /// <summary>
        /// Outputs H.264 video (400-1900 kbps, 240-480p) and AAC stereo audio
        /// </summary>
        [EnumMember(Value = "H264SingleBitrate720p")]
        H264SingleBitrate720p,

        /// <summary>
        /// Outputs H.264 video (400-1900 kbps, 240-480p) and AAC stereo audio With CVQ
        /// </summary>
        [EnumMember(Value = "H264SingleBitrate1080p")]
        H264SingleBitrate1080p,

        /// <summary>
        /// Outputs H.264 video (4500 kbps, 720p) and AAC stereo audio (128 kbps)
        /// </summary>
        [EnumMember(Value = "H264MultipleBitrateSD")]
        H264MultipleBitrateSD,

        /// <summary>
        /// Outputs H.264 video (400-3400 kbps, 180-720p) and AAC stereo audio
        /// </summary>
        H264MultipleBitrate720p,

        /// <summary>
        /// Outputs H.264 video (400-3400 kbps, 180-720p) and AAC stereo audio with CVQ
        /// </summary>
        [EnumMember(Value = "H264MultipleBitrate1080p")]
        H264MultipleBitrate1080p,

        /// <summary>
        /// Outputs H.264 video (6750 kbps, 1080p) and AAC stereo audio (128 kbps)
        /// </summary>
        [EnumMember(Value = "H264MultipleBitrateSDWithCVQ")]
        H264MultipleBitrateSDWithCVQ,

        /// <summary>
        /// Outputs H.264 video (400-6000 kbps, 180-1080p) and AAC stereo audio
        /// </summary>
        [EnumMember(Value = "H264MultipleBitrate720pWithCVQ")]
        H264MultipleBitrate720pWithCVQ,

        /// <summary>
        /// Outputs H.264 video (400-6000 kbps, 180-1080p) and AAC stereo audio with CVQ
        /// </summary>
        H264MultipleBitrate1080pWithCVQ,

        /// <summary>
        /// Outputs H.264 video (400-6000 kbps, 180-1080p) and AAC stereo audio
        /// </summary>
        [EnumMember(Value = "H264MultipleBitrateSport1080p")]
        H264MultipleBitrateSport1080p,

        /// <summary>
        /// Outputs H.265 video (400-3400 kbps, 180-720p) and AAC stereo audio
        /// </summary>
        H265SingleBitrate720p,

        /// <summary>
        /// Outputs H.265 video (3500 kbps, 1080p) and AAC stereo audio (128 kbps)
        /// </summary>
        H265SingleBitrate1080p,

        /// <summary>
        /// Outputs H.265 video (9500 kbps, 2160p) and AAC stereo audio (128 kbps)
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