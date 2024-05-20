// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace MK.IO.Models
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "@odata.type")]
    [JsonDerivedType(typeof(JobInputAsset), typeDiscriminator: "#Microsoft.Media.JobInputAsset")]
    [JsonDerivedType(typeof(JobInputHttp), typeDiscriminator: "#Microsoft.Media.JobInputHttp")]

    //
    // Summary:
    //     Base class for Job Input. A derived class must be used
    //     to create a configuration.
    public class JobInput
    {
        [JsonPropertyName("@odata.type")]
        internal virtual string OdataType { get; set; }
    }
}