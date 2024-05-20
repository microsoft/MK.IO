// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace MK.IO.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum JobErrorCategoryType
    {
        /// <summary>
        /// Enum JobErrorCategoryType for value: Account
        /// </summary>
        [EnumMember(Value = "Account")]
        Account,

        /// <summary>
        /// Enum JobErrorCategoryType for value: Configuration
        /// </summary>
        [EnumMember(Value = "Configuration")]
        Configuration,

        /// <summary>
        /// Enum JobErrorCategoryType for value: Content
        /// </summary>
        [EnumMember(Value = "Content")]
        Content,

        /// <summary>
        /// Enum JobErrorCategoryType for value: Download
        /// </summary>
        [EnumMember(Value = "Download")]
        Download,

        /// <summary>
        /// Enum JobErrorCategoryType for value: Service
        /// </summary>
        [EnumMember(Value = "Service")]
        Service,

        /// <summary>
        /// Enum JobErrorCategoryType for value: Upload
        /// </summary>
        [EnumMember(Value = "Upload")]
        Upload
    }
}