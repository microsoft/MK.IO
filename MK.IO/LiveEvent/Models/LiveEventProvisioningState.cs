// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace MK.IO.Models
{
    /// <summary>
    /// The provisioning state of the live event.
    /// </summary>
    /// <value>The current provisioning state of the live event.</value>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum LiveEventProvisioningState
    {
        //
        // Summary:
        //     InProgress live event.
        [EnumMember(Value = "InProgress")]
        InProgress,

        //
        // Summary:
        //     Succeeded live event.
        [EnumMember(Value = "Succeeded")]
        Succeeded,

        //
        // Summary:
        //     Failed live event.
        [EnumMember(Value = "Failed")]
        Failed,
    }
}