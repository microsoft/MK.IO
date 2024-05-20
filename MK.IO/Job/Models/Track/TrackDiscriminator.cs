// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace MK.IO.Models
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "@odata.type")]
    [JsonDerivedType(typeof(AudioTrackDescriptor), typeDiscriminator: "AudioTrackDescriptor")]
    [JsonDerivedType(typeof(SelectAudioTrackByAttribute), typeDiscriminator: "SelectAudioTrackByAttribute")]
    [JsonDerivedType(typeof(SelectAudioTrackById), typeDiscriminator: "SelectAudioTrackById")]
    [JsonDerivedType(typeof(SelectVideoTrackByAttribute), typeDiscriminator: "SelectVideoTrackByAttribute")]
    [JsonDerivedType(typeof(SelectVideoTrackById), typeDiscriminator: "SelectVideoTrackById")]
    [JsonDerivedType(typeof(VideoTrackDescriptor), typeDiscriminator: "VideoTrackDescriptor")]

    /// <summary>
    /// 
    /// </summary>

    public class TrackDiscriminator
    {
        [JsonPropertyName("@odata.type")]
        internal virtual string OdataType { get; set; }

    }
}
