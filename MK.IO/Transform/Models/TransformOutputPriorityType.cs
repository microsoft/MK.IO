// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace MK.IO.Models
{
    /// <summary>
    /// Sets the relative priority of the TransformOutputs within a Transform
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TransformOutputPriorityType
    {
        /// <summary>
        /// Enum TransformOutputsPriorityType for value: High
        /// </summary>
        [EnumMember(Value = "High")]
        High,

        /// <summary>
        /// Enum TransformOutputsPriorityType for value: Low
        /// </summary>
        [EnumMember(Value = "Low")]
        Low,

        /// <summary>
        /// Enum TransformOutputsPriorityType for value: Normal
        /// </summary>
        [EnumMember(Value = "Normal")]
        Normal
    }
}