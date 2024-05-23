// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace MK.IO.Models
{
    /// <summary>
    /// CDN provider name for the streaming endpoint.
    /// </summary>
    /// <value>CDN provider name for the streaming endpoint.</value>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StreamingEndpointCdnProviderType
    {
        StandardAkamai
    }
}