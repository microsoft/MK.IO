// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace MK.IO.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum FilterTrackPropertyCompareOperation
    {
        /// <summary>
        /// Enum FilterTrackOperationType for value: Equal
        /// </summary>
        [EnumMember(Value = "Equal")]
        Equal,

        /// <summary>
        /// Enum FilterTrackOperationType for value: NotEqual
        /// </summary>
        [EnumMember(Value = "NotEqual")]
        NotEqual
    }
}