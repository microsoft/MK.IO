// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.



using System.Text;
using System.Text.Json;

namespace MK.IO.Models
{

    /// <summary>
    /// 
    /// </summary>

    public class JobError
    {
        /// <summary>
        /// Gets or Sets Category
        /// </summary>
        public JobErrorCategoryType Category { get; set; }

        /// <summary>
        /// Gets or Sets Code
        /// </summary>
        public JobErrorCodeType Code { get; set; }

        /// <summary>
        /// Gets or Sets Message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or Sets Retry
        /// </summary>
        public JobErrorRetryType Retry { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class JobError {\n");
            sb.Append("  Category: ").Append(Category).Append("\n");
            sb.Append("  Code: ").Append(Code).Append("\n");
            sb.Append("  Message: ").Append(Message).Append("\n");
            sb.Append("  Retry: ").Append(Retry).Append("\n");
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
