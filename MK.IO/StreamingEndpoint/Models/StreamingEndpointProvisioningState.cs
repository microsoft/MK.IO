// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace MK.IO.Models
{
    /// <summary>
    /// The provisioning state of the streaming endpoint.
    /// </summary>
    /// <value>The provisioning state of the streaming endpoint.</value>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StreamingEndpointProvisioningState
    {
        InProgress,

        Succeeded,

        Failed
    }
}