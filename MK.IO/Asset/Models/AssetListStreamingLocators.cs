// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.


using Newtonsoft.Json;

namespace MK.IO.Models
{

    public class AssetListStreamingLocators
    {
        public static AssetListStreamingLocators FromJson(string json)
        {
            return JsonConvert.DeserializeObject<AssetListStreamingLocators>(json, ConverterLE.Settings) ?? throw new Exception("Error with asset list deserialization");
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, ConverterLE.Settings);
        }

        [JsonProperty("streamingLocators")]
        public List<AssetStreamingLocator> StreamingLocators { get; set; }
    }
}