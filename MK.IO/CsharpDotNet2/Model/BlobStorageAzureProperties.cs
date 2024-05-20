// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.



using System.Text;
using System.Text.Json;

namespace MK.IO.Models
{

    /// <summary>
    /// 
    /// </summary>

    public class BlobStorageAzureProperties
    {
        /// <summary>
        /// Gets or Sets PrivateLinkServiceConnection
        /// </summary>
        public BlobStorageAzurePrivateConnection PrivateLinkServiceConnection { get; set; }

        /// <summary>
        /// HTTP(S) URL required for access to the storage.
        /// </summary>
        /// <value>HTTP(S) URL required for access to the storage.</value>
        public string Url { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class BlobStorageAzureProperties {\n");
            sb.Append("  PrivateLinkServiceConnection: ").Append(PrivateLinkServiceConnection).Append("\n");
            sb.Append("  Url: ").Append(Url).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Get the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonSerializer.Serialize(this, ConverterLE.Settings);
        }

    }
}
