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
    public class StreamingEndpointsCurrentSku
    {
        /// <summary>
        /// This is the bandwidth capacity of current streaming unit configuration. Readonly field.
        /// </summary>
        /// <value>This is the bandwidth capacity of current streaming unit configuration. Readonly field.</value>
        [DataMember(Name = "capacity", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "capacity")]
        public int? Capacity { get; private set; } = 600;

        /// <summary>
        /// The name of the SKU. Will default to 'Standard' if the sku configuration is not provided.
        /// </summary>
        /// <value>The name of the SKU. Will default to 'Standard' if the sku configuration is not provided.</value>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "name")]
        public StreamingEndpointSkuType Name { get; set; } = StreamingEndpointSkuType.Standard;


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class StreamingEndpointsCurrentSku {\n");
            sb.Append("  Capacity: ").Append(Capacity).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
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
