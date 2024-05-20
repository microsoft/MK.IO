// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace MK.IO.Models
{
    /// <summary>
    /// The rental and lease key type.
    /// </summary>
    /// <value>The rental and lease key type.</value>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum RentalAndLeaseKeyType
    {
        [EnumMember(Value = "Unknown")]
        Unknown,

        [EnumMember(Value = "Undefined")]
        Undefined,

        [EnumMember(Value = "DualExpiry")]
        DualExpiry,

        [EnumMember(Value = "PersistentUnlimited")]
        PersistentUnlimited,

        [EnumMember(Value = "PersistentLimited")]
        PersistentLimited
    }
}