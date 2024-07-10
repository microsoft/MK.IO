// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text;
using System.Runtime.Serialization;
using System.Text.Json;

namespace MK.IO.Management.Models
{

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class ProfileGetSchemaV1
    {
        /// <summary>
        /// The kind of record.
        /// </summary>
        /// <value>The kind of record.</value>
        public string Kind { get; set; }

        /// <summary>
        /// Gets or Sets Metadata
        /// </summary>
        public UserMetadata Metadata { get; set; }

        /// <summary>
        /// Gets or Sets Spec
        /// </summary>
        public UserProfileSpecV1 Spec { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ProfileGetSchemaV1 {\n");
            sb.Append("  Kind: ").Append(Kind).Append("\n");
            sb.Append("  Metadata: ").Append(Metadata).Append("\n");
            sb.Append("  Spec: ").Append(Spec).Append("\n");
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

        public static ProfileGetSchemaV1 FromJson(string json)
        {
            return JsonSerializer.Deserialize<ProfileGetSchemaV1>(json, ConverterLE.Settings) ?? throw new Exception("Error with ProfileGetSchemaV1 deserialization");
        }
    }
}
