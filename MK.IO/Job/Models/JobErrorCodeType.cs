// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace MK.IO.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum JobErrorCodeType
    {
        /// <summary>
        /// Enum JobErrorCodeType for value: ConfigurationUnsupported
        /// </summary>
        [EnumMember(Value = "ConfigurationUnsupported")]
        ConfigurationUnsupported,

        /// <summary>
        /// Enum JobErrorCodeType for value: ContentMalformed
        /// </summary>
        [EnumMember(Value = "ContentMalformed")]
        ContentMalformed,

        /// <summary>
        /// Enum JobErrorCodeType for value: ContentUnsupported
        /// </summary>
        [EnumMember(Value = "ContentUnsupported")]
        ContentUnsupported,

        /// <summary>
        /// Enum JobErrorCodeType for value: DownloadNotAccessible
        /// </summary>
        [EnumMember(Value = "DownloadNotAccessible")]
        DownloadNotAccessible,

        /// <summary>
        /// Enum JobErrorCodeType for value: DownloadTransientError
        /// </summary>
        [EnumMember(Value = "DownloadTransientError")]
        DownloadTransientError,

        /// <summary>
        /// Enum JobErrorCodeType for value: IdentityUnsupported
        /// </summary>
        [EnumMember(Value = "IdentityUnsupported")]
        IdentityUnsupported,

        /// <summary>
        /// Enum JobErrorCodeType for value: ServiceError
        /// </summary>
        [EnumMember(Value = "ServiceError")]
        ServiceError,

        /// <summary>
        /// Enum JobErrorCodeType for value: ServiceTransientError
        /// </summary>
        [EnumMember(Value = "ServiceTransientError")]
        ServiceTransientError,

        /// <summary>
        /// Enum JobErrorCodeType for value: UploadNotAccessible
        /// </summary>
        [EnumMember(Value = "UploadNotAccessible")]
        UploadNotAccessible,

        /// <summary>
        /// Enum JobErrorCodeType for value: UploadTransientError
        /// </summary>
        [EnumMember(Value = "UploadTransientError")]
        UploadTransientError
    }
}