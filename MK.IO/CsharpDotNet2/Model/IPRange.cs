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
    public class IPRange
    {
        /// <summary>
        /// The IP address or DNS with port or protocol
        /// </summary>
        /// <value>The IP address or DNS with port or protocol</value>
        [DataMember(Name = "address", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }

        /// <summary>
        /// The name of the IP range. This is for your reference only. examples: 'everyone', 'dave's house', 'corp vpn'.
        /// </summary>
        /// <value>The name of the IP range. This is for your reference only. examples: 'everyone', 'dave's house', 'corp vpn'.</value>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// The subnet prefix length (see CIDR notation).
        /// </summary>
        /// <value>The subnet prefix length (see CIDR notation).</value>
        [DataMember(Name = "subnetPrefixLength", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "subnetPrefixLength")]
        public int? SubnetPrefixLength { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class IPRange {\n");
            sb.Append("  Address: ").Append(Address).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  SubnetPrefixLength: ").Append(SubnetPrefixLength).Append("\n");
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
