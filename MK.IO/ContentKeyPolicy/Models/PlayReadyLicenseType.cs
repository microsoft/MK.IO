// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace MK.IO.Models
{
    /// <summary>
    /// The PlayReady license type.
    /// </summary>
    /// <value>The PlayReady license type.</value>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PlayReadyLicenseType
    {
        [EnumMember(Value = "Unknown")]
        Unknown,

        [EnumMember(Value = "NonPersistent")]
        NonPersistent,

        [EnumMember(Value = "Persistent")]
        Persistent,
    }
}