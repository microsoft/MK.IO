// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace MK.IO.Models
{
    /// <summary>
    /// Sets the relative priority of the TransformOutputs within a Transform
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TransformOutputPriorityType
    {
        /// <summary>
        /// Enum TransformOutputsPriorityType for value: High
        /// </summary>
        High,

        /// <summary>
        /// Enum TransformOutputsPriorityType for value: Low
        /// </summary>
        Low,

        /// <summary>
        /// Enum TransformOutputsPriorityType for value: Normal
        /// </summary>
        Normal
    }
}