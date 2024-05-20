// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json;

namespace MK.IO.Models
{

    public class AssetListStreamingLocators
    {
        public static AssetListStreamingLocators FromJson(string json)
        {
            return JsonSerializer.Deserialize<AssetListStreamingLocators>(json, ConverterLE.Settings) ?? throw new Exception("Error with asset list deserialization");
        }

        public string ToJson()
        {
            return JsonSerializer.Serialize(this, ConverterLE.Settings);
        }

        public List<AssetStreamingLocator> StreamingLocators { get; set; }
    }
}