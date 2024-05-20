// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace MK.IO.Models
{
    /// <summary>
    /// The resource state of the live output.
    /// </summary>
    /// <value>The current resource state of the live output.</value>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum LiveOutputResourceState
    {
        //
        // Summary:
        //     Creating live output.
        Creating,

        //
        // Summary:
        //     Deleting live output.
        Deleting,

        //
        // Summary:
        //     Running live output.
        Running
    }
}