// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace MK.IO.Models
{

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class CrossSiteAccessPolicies
    {
        /// <summary>
        /// The XML content of the client access policy file. Search 'clientaccesspolicy.xml' to learn more.
        /// </summary>
        /// <value>The XML content of the client access policy file. Search 'clientaccesspolicy.xml' to learn more.</value>
        [DataMember(Name = "clientAccessPolicy", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "clientAccessPolicy")]
        public string ClientAccessPolicy { get; set; }

        /// <summary>
        /// The XML content of the cross-domain policy file. Search 'crossdomain.xml' to learn more.
        /// </summary>
        /// <value>The XML content of the cross-domain policy file. Search 'crossdomain.xml' to learn more.</value>
        [DataMember(Name = "crossDomainPolicy", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "crossDomainPolicy")]
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
            return JsonConvert.SerializeObject(this, ConverterLE.Settings);
        }

    }
}
