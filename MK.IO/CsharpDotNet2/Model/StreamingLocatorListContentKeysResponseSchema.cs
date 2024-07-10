// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json;

namespace MK.IO.Models
{

    /// <summary>
    /// 
    /// </summary>
    public class StreamingLocatorListContentKeysResponseSchema
    {
        /// <summary>
        /// The content keys used by this streaming locator
        /// </summary>
        /// <value>The content keys used by this streaming locator</value>
        public List<StreamingLocatorContentKey> ContentKeys { get; set; }


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
