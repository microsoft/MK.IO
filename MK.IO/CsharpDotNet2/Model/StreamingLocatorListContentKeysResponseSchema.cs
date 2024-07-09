// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;
using System.Runtime.Serialization;

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
        [DataMember(Name = "contentKeys", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "contentKeys")]
        public List<StreamingLocatorContentKey> ContentKeys { get; set; }


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
