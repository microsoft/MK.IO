// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace MK.IO.Models
{
    /// <summary>
    /// The provisioning state of the live output.
    /// </summary>
    /// <value>The current provisioning state of the live output.</value>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum LiveOutputProvisioningState
    {
        //
        // Summary:
        //     InProgress live output.
        InProgress,

        //
        // Summary:
        //     Succeeded live output.
        Succeeded,

        //
        // Summary:
        //     Failed live output.
        Failed
    }
}