// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace MK.IO.Models
{
    /// <summary>
    /// Configures Unknown output handling settings of the license.
    /// </summary>
    /// <value>Configures Unknown output handling settings of the license.</value>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AllowPassingVideoContentToUnknownOutput
    {
        [EnumMember(Value = "Unknown")]
        Unknown,

        [EnumMember(Value = "NotAllowed")]
        NotAllowed,

        [EnumMember(Value = "Allowed")]
        Allowed,

        [EnumMember(Value = "AllowedWithVideoConstriction")]
        AllowedWithVideoConstriction
    }
}