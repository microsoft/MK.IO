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
        [JsonProperty("customer")]
        public string Customer { get; set; }

        [JsonProperty("extra_config")]
        public ExtraConfig ExtraConfig { get; set; }

        [JsonProperty("meters")]
        public Meters Meters { get; set; }
    }

    public class ExtraConfig
    {
        [JsonProperty("cdnHostnames")]
        public CdnHostnames CdnHostnames { get; set; }
    }

    public class CdnHostnames
    {
        [JsonProperty("StandardAkamai")]
        public string StandardAkamai { get; set; }
    }

    public class Meters
    {
        [JsonProperty("egressMeterName")]
        public string EgressMeterName { get; set; }

        [JsonProperty("cdnEgressMeterName")]
        public string CdnEgressMeterName { get; set; }
    }
}