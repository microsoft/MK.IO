// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json;

namespace MK.IO.Models
{
    public partial class LocationResponseSchema
    {
        public static LocationResponseSchema FromJson(string json)
        {
            return JsonSerializer.Deserialize<LocationResponseSchema>(json, ConverterLE.Settings) ?? throw new Exception("Error with location response deserialization");
        }

        public string ToJson()
        {
            return JsonSerializer.Serialize(this, ConverterLE.Settings);
        }


        public MetadataLocation Metadata { get; set; }
    }

    public class MetadataLocation
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }
    }
}