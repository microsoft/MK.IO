// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using JsonSubTypes;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace MK.IO.Models
{
    [JsonConverter(typeof(JsonSubtypes), "@odata.type")]
    [JsonSubtypes.KnownSubType(typeof(FromEachInputFile), "FromEachInputFile")]
    [JsonSubtypes.KnownSubType(typeof(FromAllInputFile), "FromAllInputFile")]
    [JsonSubtypes.KnownSubType(typeof(InputFile), "InputFile")]

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class InputFileDiscriminator
    {
        [JsonProperty("@odata.type")]
        internal virtual string OdataType { get; set; }
    }
}
