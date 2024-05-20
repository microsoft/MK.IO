// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace MK.IO.Models
{
    /// <summary>
    /// CDN provider name for the streaming endpoint.
    /// </summary>
    /// <value>CDN provider name for the streaming endpoint.</value>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum StreamingEndpointCdnProvider
    {
        [EnumMember(Value = "StandardAkamai")]
        StandardAkamai,
    }
}