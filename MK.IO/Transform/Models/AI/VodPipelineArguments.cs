// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;

namespace MK.IO.Models
{
    public class VodPipelineArguments : PipelineArguments
    {

        public VodPipelineArguments(VodArguments arguments)
        {
            Arguments = arguments;
        }

        [JsonProperty(PropertyName = "name")]
        internal override string Name => "Predefined_ACSVodTranscription";

        public VodArguments Arguments { get; set; }

    }
}