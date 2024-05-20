// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace MK.IO.Models
{
    /// <summary>
    /// The state of the Azure Private Connection, if enabled.
    /// </summary>
    /// <value>The current state of the job.</value>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PrivateLinkServiceConnectionState
    {
        //
        // Summary:
        //     Creating.
        [EnumMember(Value = "Creating")]
        Creating,

        //
        // Summary:
        //     Pending.
        [EnumMember(Value = "Pending")]
        Pending,

        //
        // Summary:
        //     Ready.
        [EnumMember(Value = "Ready")]
        Ready,

        //
        // Summary:
        //     Running.
        [EnumMember(Value = "Running")]
        Running,

        //
        // Summary:
        //     Deleting.
        [EnumMember(Value = "Deleting")]
        Deleting,

        //
        // Summary:
        //     Deleted.
        [EnumMember(Value = "Deleted")]
        Deleted,

    }
}