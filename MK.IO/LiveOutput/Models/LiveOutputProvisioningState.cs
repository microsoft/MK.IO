// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace MK.IO.Models
{
    /// <summary>
    /// The provisioning state of the live output.
    /// </summary>
    /// <value>The current provisioning state of the live output.</value>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum LiveOutputProvisioningState
    {
        //
        // Summary:
        //     InProgress live output.
        [EnumMember(Value = "InProgress")]
        InProgress,

        //
        // Summary:
        //     Succeeded live output.
        [EnumMember(Value = "Succeeded")]
        Succeeded,

        //
        // Summary:
        //     Failed live output.
        [EnumMember(Value = "Failed")]
        Failed,
    }
}