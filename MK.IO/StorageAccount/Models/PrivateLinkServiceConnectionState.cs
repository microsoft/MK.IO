// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace MK.IO.Models
{
    /// <summary>
    /// The state of the Azure Private Connection, if enabled.
    /// </summary>
    /// <value>The current state of the job.</value>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PrivateLinkServiceConnectionState
    {
        //
        // Summary:
        //     Creating.
        Creating,

        //
        // Summary:
        //     Pending.
        Pending,

        //
        // Summary:
        //     Ready.
        Ready,

        //
        // Summary:
        //     Running.
        Running,

        //
        // Summary:
        //     Deleting.
        Deleting,

        //
        // Summary:
        //     Deleted.
        Deleted
    }
}