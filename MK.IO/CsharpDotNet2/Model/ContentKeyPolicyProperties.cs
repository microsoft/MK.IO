// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace MK.IO.Models
{

    /// <summary>
    /// The properties of the Content Key Policy.
    /// </summary>

    public class ContentKeyPolicyProperties
    {

        public ContentKeyPolicyProperties(string description, List<ContentKeyPolicyOption> options)
        {
            Description = description;
            Options = options;
        }

        /// <summary>
        /// The creation date of the Policy
        /// </summary>
        /// <value>The creation date of the Policy</value>
        [JsonInclude]
        public DateTime? Created { get; private set; }

        /// <summary>
        /// A description for the Policy.
        /// </summary>
        /// <value>A description for the Policy.</value>
        [JsonInclude] 
        public string Description { get; set; }

        /// <summary>
        /// The last modified date of the Policy
        /// </summary>
        /// <value>The last modified date of the Policy</value>
        [JsonInclude]
        public DateTime? LastModified { get; private set; }

        /// <summary>
        /// The Key Policy options.
        /// </summary>
        /// <value>The Key Policy options.</value>
        [JsonInclude]
        public List<ContentKeyPolicyOption> Options { get; set; }

        /// <summary>
        /// The legacy Policy ID.
        /// </summary>
        /// <value>The legacy Policy ID.</value>
        [JsonInclude]
        public Guid? PolicyId { get; private set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ContentKeyPolicyProperties {\n");
            sb.Append("  Created: ").Append(Created).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  LastModified: ").Append(LastModified).Append("\n");
            sb.Append("  Options: ").Append(Options).Append("\n");
            sb.Append("  PolicyId: ").Append(PolicyId).Append("\n");
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
