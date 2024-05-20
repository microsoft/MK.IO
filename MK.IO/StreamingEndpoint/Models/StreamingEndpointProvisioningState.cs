// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace MK.IO.Models
{
    /// <summary>
    /// The provisioning state of the streaming endpoint.
    /// </summary>
    /// <value>The provisioning state of the streaming endpoint.</value>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum StreamingEndpointProvisioningState
    {
        [EnumMember(Value = "InProgress")]
        InProgress,

        [EnumMember(Value = "Succeeded")]
        Succeeded,

        [EnumMember(Value = "Failed")]
        Failed
    }
}