// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace MK.IO.Management.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum UserTokenType
    {
        /// <summary>
        /// Enum UserTokenMetadataSchemaType for value: login
        /// </summary>
        [EnumMember(Value = "login")]
        Login,

        /// <summary>
        /// Enum UserTokenMetadataSchemaType for value: full-access
        /// </summary>
        [EnumMember(Value = "full-access")]
        FullAccess
    }
}