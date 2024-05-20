// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace MK.IO.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum JobErrorRetryType
    {
        /// <summary>
        /// Enum JobErrorRetryType for value: DoNotRetry
        /// </summary>
        [EnumMember(Value = "DoNotRetry")]
        DoNotRetry,

        /// <summary>
        /// Enum JobErrorRetryType for value: MayRetry
        /// </summary>
        [EnumMember(Value = "MayRetry")]
        MayRetry
    }
}