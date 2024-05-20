// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.



using System.Text;
using System.Text.Json;

namespace MK.IO.Models
{

    /// <summary>
    /// 
    /// </summary>

    public class DefaultKey
    {
        /// <summary>
        /// Labels are a potential matching field for selecting a content key via a streaming locator.
        /// </summary>
        /// <value>Labels are a potential matching field for selecting a content key via a streaming locator.</value>
        public string Label { get; set; }

        /// <summary>
        /// Policy used by the key.
        /// </summary>
        /// <value>Policy used by the key.</value>
        public string PolicyName { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class DefaultKey {\n");
            sb.Append("  Label: ").Append(Label).Append("\n");
            sb.Append("  PolicyName: ").Append(PolicyName).Append("\n");
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
