// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.



using System.Text;
using System.Text.Json;

namespace MK.IO.Models
{

    /// <summary>
    /// 
    /// </summary>

    public class AkamiHeaderAuthKey
    {
        /// <summary>
        /// Gets or Sets Base64Key
        /// </summary>
        public string Base64Key { get; set; }

        /// <summary>
        /// Gets or Sets Expiration
        /// </summary>
        public string Expiration { get; set; }

        /// <summary>
        /// Gets or Sets Identifier
        /// </summary>
        public string Identifier { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AkamiHeaderAuthKey {\n");
            sb.Append("  Base64Key: ").Append(Base64Key).Append("\n");
            sb.Append("  Expiration: ").Append(Expiration).Append("\n");
            sb.Append("  Identifier: ").Append(Identifier).Append("\n");
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
