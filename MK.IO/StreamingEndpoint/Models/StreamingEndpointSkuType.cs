// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace MK.IO.Models
{
    /// <summary>
    /// The type of the SKU. Will default to 'Standard' if the sku configuration is not provided.
    /// </summary>
    /// <value>The type of the SKU. Will default to 'Standard' if the sku configuration is not provided.</value>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum StreamingEndpointSkuType
    {
        [EnumMember(Value = "Standard")]
        Standard,

        [EnumMember(Value = "Premium")]
        Premium
    }
}