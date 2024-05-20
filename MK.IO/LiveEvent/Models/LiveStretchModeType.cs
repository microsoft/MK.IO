// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace MK.IO.Models
{
    /// <summary>
    /// Determines how aspect ratio will be preserved when there is a mismatch between the input and output aspect ratios.
    /// Autofit to pad the output. Autosize to ignore the output ratio and pick the largest dimension that fits, and None to clip the content.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum LiveStretchModeType
    {
        /// <summary>
        ///None to clip the content
        /// </summary>
        None,

        /// <summary>
        /// Autosize to ignore the output ratio and pick the largest dimension that fits
        /// </summary>
        AutoSize,

        /// <summary>
        /// Autofit to pad the output
        /// </summary>
        AutoFit
    }
}