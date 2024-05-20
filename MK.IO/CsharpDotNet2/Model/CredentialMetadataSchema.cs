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

    public class CredentialMetadataSchema
    {
        /// <summary>
        /// The date and time when the credential was created.
        /// </summary>
        /// <value>The date and time when the credential was created.</value>
        [JsonInclude]
        public DateTime? Created { get; private set; }

        /// <summary>
        /// The unique identifier of the user who created the credential.
        /// </summary>
        /// <value>The unique identifier of the user who created the credential.</value>
        [JsonInclude]
        public Guid? CreatedById { get; private set; }

        /// <summary>
        /// The unique identifier of the credential.
        /// </summary>
        /// <value>The unique identifier of the credential.</value>
        public Guid? Id { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CredentialMetadataSchema {\n");
            sb.Append("  Created: ").Append(Created).Append("\n");
            sb.Append("  CreatedById: ").Append(CreatedById).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
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
