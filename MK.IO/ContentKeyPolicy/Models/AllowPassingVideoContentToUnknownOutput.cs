// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace MK.IO.Models
{
    /// <summary>
    /// Configures Unknown output handling settings of the license.
    /// </summary>
    /// <value>Configures Unknown output handling settings of the license.</value>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum AllowPassingVideoContentToUnknownOutput
    {
        Unknown,
        NotAllowed,
        Allowed,
        AllowedWithVideoConstriction
    }
}