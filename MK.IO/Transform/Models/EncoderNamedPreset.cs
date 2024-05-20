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
        /// Enum H264SingleBitrateSD for value: H264SingleBitrateSD
        /// </summary>
        H264SingleBitrateSD,

        /// <summary>
        /// Enum H264SingleBitrate720p for value: H264SingleBitrate720p
        /// </summary>
        H264SingleBitrate720p,

        /// <summary>
        /// Enum H264SingleBitrate1080p for value: H264SingleBitrate1080p
        /// </summary>
        H264SingleBitrate1080p,

        /// <summary>
        /// Enum H264MultipleBitrateSD for value: H264MultipleBitrateSD
        /// </summary>
        H264MultipleBitrateSD,

        /// <summary>
        /// Enum H264MultipleBitrate720p for value: H264MultipleBitrate720p
        /// </summary>
        H264MultipleBitrate720p,

        /// <summary>
        /// Enum H264MultipleBitrate1080p for value: H264MultipleBitrate1080p
        /// </summary>
        H264MultipleBitrate1080p,

        /// <summary>
        /// Enum H264MultipleBitrateSDWithCVQ for value: H264MultipleBitrateSDWithCVQ
        /// </summary>
        H264MultipleBitrateSDWithCVQ,

        /// <summary>
        /// Enum H264MultipleBitrate720pWithCVQ for value: H264MultipleBitrate720pWithCVQ
        /// </summary>
        H264MultipleBitrate720pWithCVQ,

        /// <summary>
        /// Enum H264MultipleBitrate1080pWithCVQ for value: H264MultipleBitrate1080pWithCVQ
        /// </summary>
        H264MultipleBitrate1080pWithCVQ,

        /// <summary>
        /// Enum H265SingleBitrate720p for value: H265SingleBitrate720p
        /// </summary>
        H265SingleBitrate720p,

        /// <summary>
        /// Enum H265SingleBitrate1080p for value: H265SingleBitrate1080p
        /// </summary>
        H265SingleBitrate1080p,

        /// <summary>
        /// Enum H265SingleBitrate4K for value: H265SingleBitrate4K
        /// </summary>
        H265SingleBitrate4K,

        /// <summary>
        /// Enum AACGoodQualityAudio for value: AACGoodQualityAudio
        /// </summary>
        AACGoodQualityAudio
    }
}