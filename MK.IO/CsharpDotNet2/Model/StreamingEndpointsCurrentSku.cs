// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.



using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MK.IO.Models
{

    /// <summary>
    /// 
    /// </summary>

    public class StreamingEndpointsCurrentSku
    {
        /// <summary>
        /// This is the bandwidth capacity of current streaming unit configuration. Readonly field.
        /// </summary>
        /// <value>This is the bandwidth capacity of current streaming unit configuration. Readonly field.</value>
        [JsonInclude]
        public int? Capacity { get; private set; } = 600;

        /// <summary>
        /// The name of the SKU. Will default to 'Standard' if the sku configuration is not provided.
        /// </summary>
        /// <value>The name of the SKU. Will default to 'Standard' if the sku configuration is not provided.</value>


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
            return JsonSerializer.Serialize(this, ConverterLE.Settings);
        }

    }
}
