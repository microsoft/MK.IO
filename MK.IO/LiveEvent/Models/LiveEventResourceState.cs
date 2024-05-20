// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace MK.IO.Models
{
    /// <summary>
    /// The resource state of the live event.
    /// </summary>
    /// <value>The current resource state of the live event.</value>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum LiveEventResourceState
    {
        //
        // Summary:
        //     Stopped live event.
        Stopped,

        //
        // Summary:
        //     Starting live event.
        Starting,

        //
        // Summary:
        //     Running live event.
        Running,

        //
        // Summary:
        //     Stopping live event.
        Stopping,

        //
        // Summary:
        //     Deleting live event.
        Deleting
    }
}