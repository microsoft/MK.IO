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
    public class CredentialMetadataSchema
    {
        /// <summary>
        /// The date and time when the credential was created.
        /// </summary>
        /// <value>The date and time when the credential was created.</value>
        [DataMember(Name = "created", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "created")]
        public DateTime? Created { get; private set; }

        /// <summary>
        /// The unique identifier of the user who created the credential.
        /// </summary>
        /// <value>The unique identifier of the user who created the credential.</value>
        [DataMember(Name = "createdById", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "createdById")]
        public Guid? CreatedById { get; private set; }

        /// <summary>
        /// The unique identifier of the credential.
        /// </summary>
        /// <value>The unique identifier of the credential.</value>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "id")]
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
            return JsonConvert.SerializeObject(this, ConverterLE.Settings);
        }

    }
}
