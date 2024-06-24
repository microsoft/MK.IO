// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;

namespace MK.IO.Models
{
    public partial class LocationResponseSchema
    {
        public static LocationResponseSchema FromJson(string json)
        {
            return JsonConvert.DeserializeObject<LocationResponseSchema>(json, ConverterLE.Settings) ?? throw new Exception("Error with location response deserialization");
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, ConverterLE.Settings);
        }

        [JsonProperty("metadata")]
        public LocationMetadataSchema Metadata { get; set; }

        [JsonProperty("spec")]
        public LocationSpecSchema Spec { get; set; }
    }

    public class LocationMetadataSchema
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("displayName")]
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