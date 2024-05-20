// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using JsonSubTypes;
using Newtonsoft.Json;
namespace MK.IO.Models
{

    [JsonConverter(typeof(JsonSubtypes), "@odata.type")]
    [JsonSubtypes.KnownSubType(typeof(JobInputAsset), "#Microsoft.Media.JobInputAsset")]
    [JsonSubtypes.KnownSubType(typeof(JobInputHttp), "#Microsoft.Media.JobInputHttp")]

    //
    // Summary:
    //     Base class for Job Input. A derived class must be used
    //     to create a configuration.
    public class JobInput
    {
        [JsonProperty("@odata.type")]
        internal virtual string OdataType { get; set; }
    }
}