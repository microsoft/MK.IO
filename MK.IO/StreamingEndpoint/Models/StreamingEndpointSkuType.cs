// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace MK.IO.Models
{
    /// <summary>
    /// The type of the SKU. Will default to 'Standard' if the sku configuration is not provided.
    /// </summary>
    /// <value>The type of the SKU. Will default to 'Standard' if the sku configuration is not provided.</value>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StreamingEndpointSkuType
    {
        Standard,

        Premium
    }
}