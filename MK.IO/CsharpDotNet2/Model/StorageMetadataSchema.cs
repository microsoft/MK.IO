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

    public class StorageMetadataSchema
    {
        /// <summary>
        /// The date and time when the storage account was created.
        /// </summary>
        /// <value>The date and time when the storage account was created.</value>
        [JsonInclude]
        public DateTime? Created { get; private set; }

        /// <summary>
        /// The unique identifier of the user who created the storage account.
        /// </summary>
        /// <value>The unique identifier of the user who created the storage account.</value>
        [JsonInclude]
        public Guid? CreatedById { get; private set; }

        /// <summary>
        /// The unique identifier of the storage account.
        /// </summary>
        /// <value>The unique identifier of the storage account.</value>


        public Guid? Id { get; set; }

        /// <summary>
        /// The date and time when the storage account was last updated.
        /// </summary>
        /// <value>The date and time when the storage account was last updated.</value>
        [JsonInclude]
        public DateTime? Updated { get; private set; }

        /// <summary>
        /// The unique identifier of the user who last updated the storage account.
        /// </summary>
        /// <value>The unique identifier of the user who last updated the storage account.</value>
        [JsonInclude]
        public Guid? UpdatedById { get; private set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class StorageMetadataSchema {\n");
            sb.Append("  Created: ").Append(Created).Append("\n");
            sb.Append("  CreatedById: ").Append(CreatedById).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Updated: ").Append(Updated).Append("\n");
            sb.Append("  UpdatedById: ").Append(UpdatedById).Append("\n");
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
