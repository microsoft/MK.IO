// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace MK.IO.Models
{
    /// <summary>
    /// Determines the set of audio analysis operations to be performed. If unspecified, the Standard AudioAnalysisMode would be chosen.
    /// </summary>
    /// <value>Determines the set of audio analysis operations to be performed. If unspecified, the Standard AudioAnalysisMode would be chosen.</value>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AudioAnalysisMode
    {
        /// <summary>
        /// Enum Basic for value: Basic
        /// </summary>
        [EnumMember(Value = "Basic")]
        Basic,

        /// <summary>
        /// Enum Standard for value: Standard
        /// </summary>
        [EnumMember(Value = "Standard")]
        Standard
    }
}