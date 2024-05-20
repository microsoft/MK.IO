// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace MK.IO.Models
{
    /// <summary>
    /// Determines how aspect ratio will be preserved when there is a mismatch between the input and output aspect ratios.
    /// Autofit to pad the output. Autosize to ignore the output ratio and pick the largest dimension that fits, and None to clip the content.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum LiveStretchModeType
    {
        /// <summary>
        ///None to clip the content
        /// </summary>
        [EnumMember(Value = "None")]
        None,

        /// <summary>
        /// Autosize to ignore the output ratio and pick the largest dimension that fits
        /// </summary>
        [EnumMember(Value = "AutoSize")]
        AutoSize,

        /// <summary>
        /// Autofit to pad the output
        /// </summary>
        [EnumMember(Value = "AutoFit")]
        AutoFit
    }
}