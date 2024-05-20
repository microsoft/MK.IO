// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json;

namespace MK.IO.Models
{
    public partial class LocationListResponseSchema
    {
        public static LocationListResponseSchema FromJson(string json)
        {
            return JsonSerializer.Deserialize<LocationListResponseSchema>(json, ConverterLE.Settings) ?? throw new Exception("Error with location deserialization");
        }

        public string ToJson()
        {
            return JsonSerializer.Serialize(this, ConverterLE.Settings);
        }

        public string Kind { get; set; }

        public List<LocationResponseSchema> Items { get; set; }
    }
}