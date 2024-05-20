// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;

namespace MK.IO.Models
{
    public class JobInputHttp : JobInput
    {

        public JobInputHttp(string? baseUri, List<string> files)
        {
            BaseUri = baseUri;
            Files = files;
        }

        [JsonProperty("@odata.type")]
        internal override string OdataType => "#Microsoft.Media.JobInputHttp";

        /// <summary>
        /// Base URI for HTTPS job input. It will be concatenated with provided file names. If no base uri is given, then the provided file list is assumed to be fully qualified uris.
        /// </summary>
        /// <value>Base URI for HTTPS job input. It will be concatenated with provided file names. If no base uri is given, then the provided file list is assumed to be fully qualified uris.</value>
        [JsonProperty("baseUri")]
        public string? BaseUri { get; set; }

        /// <summary>
        /// (NOT IMPLEMENTED) Defines a point on the timeline of the input media at which processing will end. Defaults to the end of the input media.
        /// </summary>
        /// <value>(NOT IMPLEMENTED) Defines a point on the timeline of the input media at which processing will end. Defaults to the end of the input media.</value>
        [JsonProperty("end")]
        [Obsolete] public JobInputTime? End { get; set; }

        /// <summary>
        /// List of files. Required for JobInputHttp.
        /// </summary>
        /// <value>List of files. Required for JobInputHttp.</value>
        [JsonProperty("files")]
        public List<string> Files { get; set; }

        /// <summary>
        /// Defines a list of InputDefinitions
        /// </summary>
        /// <value>Defines a list of InputDefinitions</value>
        [JsonProperty(PropertyName = "inputDefinitions")]
        public List<InputFileDiscriminator> InputDefinitions { get; set; }

        /// <summary>
        /// A label that is assigned to a JobInputClip
        /// </summary>
        /// <value>A label that is assigned to a JobInputClip</value>
        [JsonProperty(PropertyName = "label")]
        public string Label { get; set; }

        /// <summary>
        /// (NOT IMPLEMENTED) Defines a point on the timeline of the input media at which processing will start. Defaults to the beginning of the input media.
        /// </summary>
        /// <value>(NOT IMPLEMENTED) Defines a point on the timeline of the input media at which processing will start. Defaults to the beginning of the input media..</value>
        [JsonProperty("start")]
        [Obsolete] public JobInputTime? Start { get; set; }
    }
}