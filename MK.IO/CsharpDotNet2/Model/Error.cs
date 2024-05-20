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

    public class Error
    {
        /// <summary>
        /// Gets or Sets _Error
        /// </summary>
        [JsonPropertyName("error")]
        public ErrorDetail _Error { get; set; }

        /// <summary>
        /// A reference to the request that caused the error.
        /// </summary>
        /// <value>A reference to the request that caused the error.</value>
        [JsonPropertyName("ref")]
        public string _Ref { get; set; }

        /// <summary>
        /// The HTTP status code
        /// </summary>
        /// <value>The HTTP status code</value>
        public int? Status { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Error {\n");
            sb.Append("  _Error: ").Append(_Error).Append("\n");
            sb.Append("  _Ref: ").Append(_Ref).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
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
