// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace MK.IO.Models
{
    /// <summary>
    /// The encryption scheme used for the path.
    /// </summary>
    /// <value>The encryption scheme used for the path.</value>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StreamingPathsEncryptionScheme
    {
        NoEncryption,

        CommonEncryptionCenc,

        CommonEncryptionCbcs,

        EnvelopeEncryption
    }
}