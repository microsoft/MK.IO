// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace MK.IO.Models
{
    /// <summary>
    /// The resource state of the streaming endpoint.
    /// </summary>
    /// <value>The resource state of the streaming endpoint.</value>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StreamingEndpointResourceState
    {
        Running,

        Stopped,

        Deleted,

        Starting,

        Stopping,

        Deleting,

        Scaling,

        Creating
    }
}