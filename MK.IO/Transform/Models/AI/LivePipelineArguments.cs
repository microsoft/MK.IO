// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;

namespace MK.IO.Models
{
    public class LivePipelineArguments : PipelineArguments
    {
        public LivePipelineArguments(LiveArguments arguments)
        {
            Arguments = arguments;
        }

        [JsonProperty(PropertyName = "name")]
        internal override string Name => "Predefined_ACSLiveTranscription";

        public LiveArguments Arguments { get; set; }

    }
}