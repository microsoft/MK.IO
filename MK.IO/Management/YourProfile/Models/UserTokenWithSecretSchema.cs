// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json;

namespace MK.IO.Management.Models
{

    /// <summary>
    /// 
    /// </summary>
    public class UserTokenWithSecretSchema
    {
        /// <summary>
        /// Gets or Sets Metadata
        /// </summary>
        public UserTokenWithSecretMetadataSchema Metadata { get; set; }

        /// <summary>
        /// Gets or Sets Spec
        /// </summary>
        public UserTokenSpecSchema Spec { get; set; }

        public static UserTokenWithSecretSchema FromJson(string json)
        {
            return JsonSerializer.Deserialize<UserTokenWithSecretSchema>(json, ConverterLE.Settings) ?? throw new Exception("Error with UserTokenWithSecretSchema deserialization");
        }
    }
}
