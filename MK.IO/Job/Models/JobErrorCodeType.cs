// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace MK.IO.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum JobErrorCodeType
    {
        /// <summary>
        /// Enum JobErrorCodeType for value: ConfigurationUnsupported
        /// </summary>
        ConfigurationUnsupported,

        /// <summary>
        /// Enum JobErrorCodeType for value: ContentMalformed
        /// </summary>
        ContentMalformed,

        /// <summary>
        /// Enum JobErrorCodeType for value: ContentUnsupported
        /// </summary>
        ContentUnsupported,

        /// <summary>
        /// Enum JobErrorCodeType for value: DownloadNotAccessible
        /// </summary>
        DownloadNotAccessible,

        /// <summary>
        /// Enum JobErrorCodeType for value: DownloadTransientError
        /// </summary>
        DownloadTransientError,

        /// <summary>
        /// Enum JobErrorCodeType for value: IdentityUnsupported
        /// </summary>
        IdentityUnsupported,

        /// <summary>
        /// Enum JobErrorCodeType for value: ServiceError
        /// </summary>
        ServiceError,

        /// <summary>
        /// Enum JobErrorCodeType for value: ServiceTransientError
        /// </summary>
        ServiceTransientError,

        /// <summary>
        /// Enum JobErrorCodeType for value: UploadNotAccessible
        /// </summary>
        UploadNotAccessible,

        /// <summary>
        /// Enum JobErrorCodeType for value: UploadTransientError
        /// </summary>
        UploadTransientError
    }
}