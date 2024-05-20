// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace MK.IO.Models
{
    /// <summary>
    /// Priority with which the job should be processed. Higher priority jobs are processed before lower priority jobs. If not set, the default is normal.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum JobPriorityType
    {
        /// <summary>
        /// Enum JobPriorityType for value: High
        /// </summary>
        [EnumMember(Value = "High")]
        High,

        /// <summary>
        /// Enum JobPriorityType for value: Low
        /// </summary>
        [EnumMember(Value = "Low")]
        Low,

        /// <summary>
        /// Enum JobPriorityType for value: Normal
        /// </summary>
        [EnumMember(Value = "Normal")]
        Normal
    }
}