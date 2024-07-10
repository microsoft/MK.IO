// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace MK.IO.Management.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
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