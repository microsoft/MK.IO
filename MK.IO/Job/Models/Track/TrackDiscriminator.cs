// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using JsonSubTypes;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace MK.IO.Models
{
    [JsonConverter(typeof(JsonSubtypes), "@odata.type")]
    [JsonSubtypes.KnownSubType(typeof(AudioTrackDescriptor), "AudioTrackDescriptor")]
    [JsonSubtypes.KnownSubType(typeof(SelectAudioTrackByAttribute), "SelectAudioTrackByAttribute")]
    [JsonSubtypes.KnownSubType(typeof(SelectAudioTrackById), "SelectAudioTrackById")]
    [JsonSubtypes.KnownSubType(typeof(SelectVideoTrackByAttribute), "SelectVideoTrackByAttribute")]
    [JsonSubtypes.KnownSubType(typeof(SelectVideoTrackById), "SelectVideoTrackById")]
    [JsonSubtypes.KnownSubType(typeof(VideoTrackDescriptor), "VideoTrackDescriptor")]


    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class TrackDiscriminator
    {

        [JsonProperty("@odata.type")]
        internal virtual string OdataType { get; set; }

    }
}
