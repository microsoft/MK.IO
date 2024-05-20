// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace MK.IO.Models
{
    /// <summary>
    /// Deletion Policy type.
    /// </summary>
    /// <value>Deletion Policy type.</value>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum AssetContainerDeletionPolicyType
    {
        /// <summary>
        /// A deletion policy of 'Retain' will leave the content in-place in your storage account.
        /// </summary>
        Retain,

        /// <summary>
        /// A deletion policy of 'Delete' will result in the associated storage container and all its contents being removed from storage.
        /// </summary>
        Delete
    }
}