// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace MK.IO.Models
{
    /// <summary>
    /// The current state of the job.
    /// </summary>
    /// <value>The current state of the job.</value>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum JobState
    {
        //
        // Summary:
        //     The job was canceled. This is a final state for the job.
        Canceled,

        //
        // Summary:
        //     The job is in the process of being canceled. This is a transient state for the
        //     job.
        Canceling,

        //
        // Summary:
        //     The job has encountered an error. This is a final state for the job.
        Error,

        //
        // Summary:
        //     The job is finished. This is a final state for the job.
        Finished,

        //
        // Summary:
        //     The job is processing. This is a transient state for the job.
        Processing,

        //
        // Summary:
        //     The job is in a queued state, waiting for resources to become available. This
        //     is a transient state.
        Queued,

        //
        // Summary:
        //     The job is being scheduled to run on an available resource. This is a transient
        //     state, between queued and processing states.
        Scheduled
    }
}