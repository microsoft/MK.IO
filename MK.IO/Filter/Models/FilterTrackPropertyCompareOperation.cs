// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace MK.IO.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum FilterTrackPropertyCompareOperation
    {
        /// <summary>
        /// Enum FilterTrackOperationType for value: Equal
        /// </summary>
        Equal,

        /// <summary>
        /// Enum FilterTrackOperationType for value: NotEqual
        /// </summary>
        NotEqual
    }
}