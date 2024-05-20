// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace MK.IO.Models
{
    /// <summary>
    /// The streaming locator content key type.
    /// </summary>
    /// <value>The streaming locator content key type.</value>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum StreamingLocatorContentKeyType
    {
        [EnumMember(Value = "CommonEncryptionCenc")]
        CommonEncryptionCenc,

        [EnumMember(Value = "CommonEncryptionCbcs")]
        CommonEncryptionCbcs,

        [EnumMember(Value = "EnvelopeEncryption")]
        EnvelopeEncryption,
    }
}