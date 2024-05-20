// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace MK.IO.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum JobErrorCategoryType
    {
        /// <summary>
        /// Enum JobErrorCategoryType for value: Account
        /// </summary>
        Account,

        /// <summary>
        /// Enum JobErrorCategoryType for value: Configuration
        /// </summary>
        Configuration,

        /// <summary>
        /// Enum JobErrorCategoryType for value: Content
        /// </summary>
        Content,

        /// <summary>
        /// Enum JobErrorCategoryType for value: Download
        /// </summary>
        Download,

        /// <summary>
        /// Enum JobErrorCategoryType for value: Service
        /// </summary>
        Service,

        /// <summary>
        /// Enum JobErrorCategoryType for value: Upload
        /// </summary>
        Upload
    }
}