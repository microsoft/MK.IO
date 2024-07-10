﻿// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using JsonSubTypes;
using Newtonsoft.Json;
namespace MK.IO.Models
{

    [JsonConverter(typeof(JsonSubtypes), "@odata.type")]
    [JsonSubtypes.KnownSubType(typeof(BuiltInStandardEncoderPreset), "#Microsoft.Media.BuiltInStandardEncoderPreset")]
    [JsonSubtypes.KnownSubType(typeof(BuiltInAssetConverterPreset), "#Microsoft.Media.BuiltInAssetConverterPreset")]
    [JsonSubtypes.KnownSubType(typeof(ThumbnailGeneratorPreset), "#Microsoft.Media.ThumbnailGeneratorPreset")]

    //
    // Summary:
    //     Base class for Transform Output preset configuration. A derived class must be used
    //     to create a configuration.
    public class TransformPreset
    {
        [JsonProperty("@odata.type")]
        internal virtual string OdataType { get; set; }
    }
}