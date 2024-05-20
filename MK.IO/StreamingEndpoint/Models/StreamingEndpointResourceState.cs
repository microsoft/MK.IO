// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace MK.IO.Models
{
    /// <summary>
    /// The resource state of the streaming endpoint.
    /// </summary>
    /// <value>The resource state of the streaming endpoint.</value>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum StreamingEndpointResourceState
    {
        [EnumMember(Value = "Running")]
        Running,

        [EnumMember(Value = "Stopped")]
        Stopped,

        [EnumMember(Value = "Deleted")]
        Deleted,

        [EnumMember(Value = "Starting")]
        Starting,

        [EnumMember(Value = "Stopping")]
        Stopping,

        [EnumMember(Value = "Deleting")]
        Deleting,

        [EnumMember(Value = "Scaling")]
        Scaling,

        [EnumMember(Value = "Creating")]
        Creating
    }
}