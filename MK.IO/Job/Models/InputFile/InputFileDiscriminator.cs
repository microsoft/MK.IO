// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using JsonSubTypes;
using System.Text.Json.Serialization;

namespace MK.IO.Models
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "@odata.type")]
    [JsonDerivedType(typeof(FromEachInputFile), typeDiscriminator: "FromEachInputFile")]
    [JsonDerivedType(typeof(FromAllInputFile), typeDiscriminator: "FromAllInputFile")]
    [JsonDerivedType(typeof(InputFile), typeDiscriminator: "InputFile")]

    /// <summary>
    /// 
    /// </summary>

    public class InputFileDiscriminator
    {
        [JsonPropertyName("@odata.type")]
        internal virtual string OdataType { get; set; }
    }
}
