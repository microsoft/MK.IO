// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.



using System.Text;
using System.Text.Json;

namespace MK.IO.Models
{

    /// <summary>
    /// 
    /// </summary>

    public class StreamingPolicyProperties
    {
        /// <summary>
        /// Gets or Sets CommonEncryptionCbcs
        /// </summary>
        public CommonEncryptionCbcs CommonEncryptionCbcs { get; set; }

        /// <summary>
        /// Gets or Sets CommonEncryptionCenc
        /// </summary>
        public CommonEncryptionCenc CommonEncryptionCenc { get; set; }

        /// <summary>
        /// The default content key policy name used by current streaming policy.
        /// </summary>
        /// <value>The default content key policy name used by current streaming policy.</value>
        public string DefaultContentKeyPolicyName { get; set; }

        /// <summary>
        /// Gets or Sets EnvelopeEncryption
        /// </summary>
        public EnvelopeEncryption EnvelopeEncryption { get; set; }

        /// <summary>
        /// Gets or Sets NoEncryption
        /// </summary>
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
            return JsonSerializer.Serialize(this, ConverterLE.Settings);
        }

    }
}
