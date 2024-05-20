// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace MK.IO.Models
{
    /// <summary>
    /// The provisioning state of the live event.
    /// </summary>
    /// <value>The current provisioning state of the live event.</value>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum LiveEventProvisioningState
    {
        //
        // Summary:
        //     InProgress live event.
        InProgress,

        //
        // Summary:
        //     Succeeded live event.
        Succeeded,

        //
        // Summary:
        //     Failed live event.
        Failed
    }
}