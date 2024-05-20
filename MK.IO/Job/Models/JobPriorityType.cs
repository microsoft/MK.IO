// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace MK.IO.Models
{
    /// <summary>
    /// Priority with which the job should be processed. Higher priority jobs are processed before lower priority jobs. If not set, the default is normal.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum JobPriorityType
    {
        /// <summary>
        /// Enum JobPriorityType for value: High
        /// </summary>
        High,

        /// <summary>
        /// Enum JobPriorityType for value: Low
        /// </summary>
        Low,

        /// <summary>
        /// Enum JobPriorityType for value: Normal
        /// </summary>
        Normal
    }
}