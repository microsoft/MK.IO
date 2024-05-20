// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.



using System.Text;
using System.Text.Json;

namespace MK.IO.Models
{

    /// <summary>
    /// 
    /// </summary>

    public class CrossSiteAccessPolicies
    {
        /// <summary>
        /// The XML content of the client access policy file. Search 'clientaccesspolicy.xml' to learn more.
        /// </summary>
        /// <value>The XML content of the client access policy file. Search 'clientaccesspolicy.xml' to learn more.</value>
        public string ClientAccessPolicy { get; set; }

        /// <summary>
        /// The XML content of the cross-domain policy file. Search 'crossdomain.xml' to learn more.
        /// </summary>
        /// <value>The XML content of the cross-domain policy file. Search 'crossdomain.xml' to learn more.</value>
        public string CrossDomainPolicy { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CrossSiteAccessPolicies {\n");
            sb.Append("  ClientAccessPolicy: ").Append(ClientAccessPolicy).Append("\n");
            sb.Append("  CrossDomainPolicy: ").Append(CrossDomainPolicy).Append("\n");
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
