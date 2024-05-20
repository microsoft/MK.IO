// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.



using System.Text;
using System.Text.Json;

namespace MK.IO.Models
{

    /// <summary>
    /// 
    /// </summary>

    public class ContentKeyPolicyOptions
    {
        /// <summary>
        /// An optional description of the streaming policy.
        /// </summary>
        /// <value>An optional description of the streaming policy.</value>
        public string Description { get; set; }

        /// <summary>
        /// The key policy options
        /// </summary>
        /// <value>The key policy options</value>
        public List<ContentKeyPolicyOption> Options { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ContentKeyPolicyOptions {\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Options: ").Append(Options).Append("\n");
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
