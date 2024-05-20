// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using JsonSubTypes;
using Newtonsoft.Json;
namespace MK.IO.Models
{

    [JsonConverter(typeof(JsonSubtypes), "@odata.type")]
    [JsonSubtypes.KnownSubType(typeof(UtcClipTime), "#Microsoft.Media.UtcClipTime")]
    [JsonSubtypes.KnownSubType(typeof(AbsoluteClipTime), "#Microsoft.Media.AbsoluteClipTime")]

    //
    // Summary:
    //     Base class for Job Start. A derived class must be used
    //     to create a configuration.
    public class JobInputTime
    {
        [JsonProperty("@odata.type")]
        internal virtual string OdataType { get; set; }
    }
}