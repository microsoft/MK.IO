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
    public class StreamingPolicyProperties
    {
        /// <summary>
        /// Gets or Sets CommonEncryptionCbcs
        /// </summary>
        [DataMember(Name = "commonEncryptionCbcs", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "commonEncryptionCbcs")]
        public CommonEncryptionCbcs CommonEncryptionCbcs { get; set; }

        /// <summary>
        /// Gets or Sets CommonEncryptionCenc
        /// </summary>
        [DataMember(Name = "commonEncryptionCenc", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "commonEncryptionCenc")]
        public CommonEncryptionCenc CommonEncryptionCenc { get; set; }

        /// <summary>
        /// The default content key policy name used by current streaming policy.
        /// </summary>
        /// <value>The default content key policy name used by current streaming policy.</value>
        [DataMember(Name = "defaultContentKeyPolicyName", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "defaultContentKeyPolicyName")]
        public string DefaultContentKeyPolicyName { get; set; }

        /// <summary>
        /// Gets or Sets EnvelopeEncryption
        /// </summary>
        [DataMember(Name = "envelopeEncryption", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "envelopeEncryption")]
        public EnvelopeEncryption EnvelopeEncryption { get; set; }

        /// <summary>
        /// Gets or Sets NoEncryption
        /// </summary>
        [DataMember(Name = "noEncryption", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "noEncryption")]
        public NoEncryption NoEncryption { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class StreamingPolicyProperties {\n");
            sb.Append("  CommonEncryptionCbcs: ").Append(CommonEncryptionCbcs).Append("\n");
            sb.Append("  CommonEncryptionCenc: ").Append(CommonEncryptionCenc).Append("\n");
            sb.Append("  DefaultContentKeyPolicyName: ").Append(DefaultContentKeyPolicyName).Append("\n");
            sb.Append("  EnvelopeEncryption: ").Append(EnvelopeEncryption).Append("\n");
            sb.Append("  NoEncryption: ").Append(NoEncryption).Append("\n");
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
