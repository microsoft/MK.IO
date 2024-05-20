// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.



using System.Text;
using System.Text.Json;

namespace MK.IO.Models
{

    /// <summary>
    /// 
    /// </summary>

    public class StreamingEndpointAkamiACL
    {
        /// <summary>
        /// The Akamai access control configuration for the streaming endpoint. Learn more: https://techdocs.akamai.com/netstorage-usage/reference/example-authentication-headers
        /// </summary>
        /// <value>The Akamai access control configuration for the streaming endpoint. Learn more: https://techdocs.akamai.com/netstorage-usage/reference/example-authentication-headers</value>
        public List<AkamiHeaderAuthKey> AkamaiSignatureHeaderAuthenticationKeyList { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class StreamingEndpointAkamiACL {\n");
            sb.Append("  AkamaiSignatureHeaderAuthenticationKeyList: ").Append(AkamaiSignatureHeaderAuthenticationKeyList).Append("\n");
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
