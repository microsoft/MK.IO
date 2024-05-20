// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace MK.IO.Models
{
    /// <summary>
    /// The encryption scheme used for the path.
    /// </summary>
    /// <value>The encryption scheme used for the path.</value>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum StreamingPathsEncryptionScheme
    {
        [EnumMember(Value = "NoEncryption")]
        NoEncryption,

        [EnumMember(Value = "CommonEncryptionCenc")]
        CommonEncryptionCenc,

        [EnumMember(Value = "CommonEncryptionCbcs")]
        CommonEncryptionCbcs,

        [EnumMember(Value = "EnvelopeEncryption")]
        EnvelopeEncryption,
    }
}