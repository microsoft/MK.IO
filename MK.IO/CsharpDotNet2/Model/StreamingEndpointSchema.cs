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

    public class StreamingEndpointSchema
    {
        /// <summary>
        /// The name of the location in which the streaming endpoint is located. This field must match the location in which the user's subscription is provisioned.
        /// </summary>
        /// <value>The name of the location in which the streaming endpoint is located. This field must match the location in which the user's subscription is provisioned.</value>
        public string Location { get; set; }

        /// <summary>
        /// The name of the resource
        /// </summary>
        /// <value>The name of the resource</value>
        [JsonInclude]
        public string Name { get; private set; }

        /// <summary>
        /// Gets or Sets Properties
        /// </summary>
        public StreamingEndpointProperties Properties { get; set; }

        /// <summary>
        /// A dictionary of key:value pairs describing the resource. Search may be implemented against tags in the future.
        /// </summary>
        /// <value>A dictionary of key:value pairs describing the resource. Search may be implemented against tags in the future.</value>
        public Dictionary<string, string> Tags { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class StreamingEndpointSchema {\n");
            sb.Append("  Location: ").Append(Location).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Properties: ").Append(Properties).Append("\n");
            sb.Append("  Tags: ").Append(Tags).Append("\n");
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
