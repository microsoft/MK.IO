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

    public class SystemDataSchema
    {
        /// <summary>
        /// The timestamp of resource creation (UTC).
        /// </summary>
        /// <value>The timestamp of resource creation (UTC).</value>
        [JsonInclude]
        public DateTime? CreatedAt { get; private set; }

        /// <summary>
        /// The identity that created the resource.
        /// </summary>
        /// <value>The identity that created the resource.</value>
        [JsonInclude]
        public string CreatedBy { get; private set; }

        /// <summary>
        /// The type of identity that created the resource.
        /// </summary>
        /// <value>The type of identity that created the resource.</value>
        [JsonInclude]
        public string CreatedByType { get; private set; }

        /// <summary>
        /// The timestamp of resource last modification (UTC).
        /// </summary>
        /// <value>The timestamp of resource last modification (UTC).</value>
        [JsonInclude]
        public DateTime? LastModifiedAt { get; private set; }

        /// <summary>
        /// The identity that last modified the resource.
        /// </summary>
        /// <value>The identity that last modified the resource.</value>
        [JsonInclude]
        public string LastModifiedBy { get; private set; }

        /// <summary>
        /// The type of identity that last modified the resource.
        /// </summary>
        /// <value>The type of identity that last modified the resource.</value>
        [JsonInclude]
        public string LastModifiedByType { get; private set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SystemDataSchema {\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  CreatedBy: ").Append(CreatedBy).Append("\n");
            sb.Append("  CreatedByType: ").Append(CreatedByType).Append("\n");
            sb.Append("  LastModifiedAt: ").Append(LastModifiedAt).Append("\n");
            sb.Append("  LastModifiedBy: ").Append(LastModifiedBy).Append("\n");
            sb.Append("  LastModifiedByType: ").Append(LastModifiedByType).Append("\n");
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
