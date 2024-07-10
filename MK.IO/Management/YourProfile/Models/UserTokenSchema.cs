// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json;

namespace MK.IO.Management.Models
{

    /// <summary>
    /// 
    /// </summary>
    public class UserTokenSchema
    {
        /// <summary>
        /// Gets or Sets Metadata
        /// </summary>
        public UserTokenMetadataSchema Metadata { get; set; }

        /// <summary>
        /// Gets or Sets Spec
        /// </summary>
        public UserTokenSpecSchema Spec { get; set; }

        public static UserTokenSchema FromJson(string json)
        {
            return JsonSerializer.Deserialize<UserTokenSchema>(json, ConverterLE.Settings) ?? throw new Exception("Error with UserTokenSchema deserialization");
        }
    }
}
