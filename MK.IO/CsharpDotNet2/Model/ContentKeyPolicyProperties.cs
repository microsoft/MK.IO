// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace MK.IO.Models
{

    /// <summary>
    /// The properties of the Content Key Policy.
    /// </summary>
    [DataContract]
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
        [DataMember(Name = "created", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "created")]
        public DateTime? Created { get; private set; }

        /// <summary>
        /// A description for the Policy.
        /// </summary>
        /// <value>A description for the Policy.</value>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// FairPlay AMS compatibility enabled.
        /// </summary>
        /// <value>FairPlay AMS compatibility enabled.</value>
        [DataMember(Name = "fairPlayAmsCompatibility", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "fairPlayAmsCompatibility")]
        public bool? FairPlayAmsCompatibility { get; set; }

        /// <summary>
        /// The last modified date of the Policy
        /// </summary>
        /// <value>The last modified date of the Policy</value>
        [DataMember(Name = "lastModified", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "lastModified")]
        public DateTime? LastModified { get; private set; }

        /// <summary>
        /// The Key Policy options.
        /// </summary>
        /// <value>The Key Policy options.</value>
        [DataMember(Name = "options", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "options")]
        public List<ContentKeyPolicyOption> Options { get; set; }

        /// <summary>
        /// The legacy Policy ID.
        /// </summary>
        /// <value>The legacy Policy ID.</value>
        [DataMember(Name = "policyId", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "policyId")]
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
            sb.Append("  FairPlayAmsCompatibility: ").Append(FairPlayAmsCompatibility).Append("\n");
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
            return JsonConvert.SerializeObject(this, ConverterLE.Settings);
        }

    }
}
