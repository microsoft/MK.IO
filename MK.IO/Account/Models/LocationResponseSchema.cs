// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json;
using System.Text.Json.Serialization;

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

        public LocationMetadataSchema Metadata { get; set; }

        public LocationSpecSchema Spec { get; set; }
    }

    public class LocationMetadataSchema
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }
    }

    public class LocationSpecSchema
    {
        public string Customer { get; set; }

        [JsonPropertyName("extra_config")]
        public ExtraConfig ExtraConfig { get; set; }

        public Meters Meters { get; set; }
    }

    public class ExtraConfig
    {
        public CdnHostnames CdnHostnames { get; set; }
    }

    public class CdnHostnames
    {
        public string StandardAkamai { get; set; }
    }

    public class Meters
    {
        public string EgressMeterName { get; set; }

        public string CdnEgressMeterName { get; set; }
    }
}