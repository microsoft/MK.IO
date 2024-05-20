// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace MK.IO.Models
{
    /// <summary>
    /// The rental and lease key type.
    /// </summary>
    /// <value>The rental and lease key type.</value>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RentalAndLeaseKeyType
    {
        Unknown,

        Undefined,

        DualExpiry,

        PersistentUnlimited,

        PersistentLimited
    }
}