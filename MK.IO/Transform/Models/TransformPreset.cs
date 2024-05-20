// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace MK.IO.Models
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "@odata.type")]
    [JsonDerivedType(typeof(BuiltInStandardEncoderPreset), typeDiscriminator: "#Microsoft.Media.BuiltInStandardEncoderPreset")]
    [JsonDerivedType(typeof(AudioAnalyzerPreset), typeDiscriminator: "#Microsoft.Media.AudioAnalyzerPreset")]

    //
    // Summary:
    //     Base class for Transform Output preset configuration. A derived class must be used
    //     to create a configuration.
    public class TransformPreset
    {
        [JsonPropertyName("@odata.type")]
        internal virtual string OdataType { get; set; }
    }
}