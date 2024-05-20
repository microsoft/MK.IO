// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;
using System.Xml;

namespace MK.IO
{
    internal static class ConverterLE
    {
        public static readonly JsonSerializerSettings Settings = new()
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore,
            Formatting = Newtonsoft.Json.Formatting.Indented,
            Converters =
            {
                new CustomDateTimeConverter(),
                new CustomTimeSpanConverter()
            },
        };
    }

    internal class CustomDateTimeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(DateTime)) || (objectType == typeof(DateTime?));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            if (objectType == typeof(DateTime?))
            {
                if (reader.Value == null)
                {
                    return (DateTime?)null;
                }
                return (DateTime?)reader.Value;
            }
            else if (objectType == typeof(DateTime))
            {
                return (DateTime)reader.Value;
            }

            return DateTime.Parse(reader.Value.ToString());
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            if (value is not null and DateTime)
            {
                // We need to reduce the precision. See issue https://github.com/xpouyat/MK.IO/issues/43
                // We limit the conversion of DateTime to the format "yyyy-MM-ddTHH:mm:ss.ffZ"
                writer.WriteValue(((DateTime)value).ToString("yyyy-MM-ddTHH:mm:ss.ffZ"));
            }
        }
    }

    internal class CustomTimeSpanConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(TimeSpan)) || (objectType == typeof(TimeSpan?));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            if (objectType == typeof(TimeSpan?))
            {
                if (reader.Value == null)
                {
                    return (TimeSpan?)null;
                }
                return XmlConvert.ToTimeSpan(reader.Value.ToString());
            }
            else if (objectType == typeof(TimeSpan))
            {
                return XmlConvert.ToTimeSpan(reader.Value.ToString());
            }
            return XmlConvert.ToTimeSpan(reader.Value.ToString());
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            if (value is not null and TimeSpan)
            {
                // convert TimeSpan to ISO 8601 format
                writer.WriteValue(XmlConvert.ToString((TimeSpan)value));
            }
        }
    }
}