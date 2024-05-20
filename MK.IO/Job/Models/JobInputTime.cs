// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace MK.IO.Models
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "@odata.type")]
    [JsonDerivedType(typeof(UtcClipTime), typeDiscriminator: "#Microsoft.Media.UtcClipTime")]
    [JsonDerivedType(typeof(AbsoluteClipTime), typeDiscriminator: "#Microsoft.Media.AbsoluteClipTime")]

    //
    // Summary:
    //     Base class for Job Start. A derived class must be used
    //     to create a configuration.
    public class JobInputTime
    {
        [JsonPropertyName("@odata.type")]
        internal virtual string OdataType { get; set; }
    }
}