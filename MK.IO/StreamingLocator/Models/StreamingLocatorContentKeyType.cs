// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace MK.IO.Models
{
    /// <summary>
    /// The streaming locator content key type.
    /// </summary>
    /// <value>The streaming locator content key type.</value>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StreamingLocatorContentKeyType
    {
        CommonEncryptionCenc,

        CommonEncryptionCbcs,

        EnvelopeEncryption
    }
}