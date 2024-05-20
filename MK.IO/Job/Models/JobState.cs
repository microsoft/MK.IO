// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace MK.IO.Models
{
    /// <summary>
    /// The current state of the job.
    /// </summary>
    /// <value>The current state of the job.</value>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum JobState
    {
        //
        // Summary:
        //     The job was canceled. This is a final state for the job.
        [EnumMember(Value = "Canceled")]
        Canceled,

        //
        // Summary:
        //     The job is in the process of being canceled. This is a transient state for the
        //     job.
        [EnumMember(Value = "Canceling")]
        Canceling,

        //
        // Summary:
        //     The job has encountered an error. This is a final state for the job.
        [EnumMember(Value = "Error")]
        Error,

        //
        // Summary:
        //     The job is finished. This is a final state for the job.
        [EnumMember(Value = "Finished")]
        Finished,

        //
        // Summary:
        //     The job is processing. This is a transient state for the job.
        [EnumMember(Value = "Processing")]
        Processing,

        //
        // Summary:
        //     The job is in a queued state, waiting for resources to become available. This
        //     is a transient state.
        [EnumMember(Value = "Queued")]
        Queued,

        //
        // Summary:
        //     The job is being scheduled to run on an available resource. This is a transient
        //     state, between queued and processing states.
        [EnumMember(Value = "Scheduled")]
        Scheduled
    }
}