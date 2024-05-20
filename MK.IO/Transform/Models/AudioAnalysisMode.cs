// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace MK.IO.Models
{
    /// <summary>
    /// Determines the set of audio analysis operations to be performed. If unspecified, the Standard AudioAnalysisMode would be chosen.
    /// </summary>
    /// <value>Determines the set of audio analysis operations to be performed. If unspecified, the Standard AudioAnalysisMode would be chosen.</value>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum AudioAnalysisMode
    {
        /// <summary>
        /// Enum Basic for value: Basic
        /// </summary>
        Basic,

        /// <summary>
        /// Enum Standard for value: Standard
        /// </summary>
        Standard
    }
}