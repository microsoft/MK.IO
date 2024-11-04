// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using JsonSubTypes;
using Newtonsoft.Json;

namespace MK.IO.Models
{

    [JsonConverter(typeof(JsonSubtypes), "name")]
    [JsonSubtypes.KnownSubType(typeof(VodPipelineArguments), "Predefined_ACSVodTranscription")]
    [JsonSubtypes.KnownSubType(typeof(LivePipelineArguments), "Predefined_ACSLiveTranscription")]

    //
    // Summary:
    //     Base class for AI Pipeline configuration. A derived class must be used
    //     to create a configuration.
    public class PipelineArguments
    {
        [JsonProperty(PropertyName = "name")]
        internal virtual string Name { get; set; }
    }
}