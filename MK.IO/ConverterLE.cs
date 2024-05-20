// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml;

namespace MK.IO
{
    internal static class ConverterLE
    {
        /*
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
        */

        public static readonly JsonSerializerOptions Settings = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true,
            AllowOutOfOrderMetadataProperties = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            Converters = {
                new JsonStringEnumConverter(),
                new CustomDateTimeConverter(),
                new CustomDateTimeNConverter(),
                new CustomTimeSpanConverter(),
                new CustomTimeSpanNConverter()
            },
        };
    }


    internal class CustomDateTimeNConverter : JsonConverter<DateTime?>
    {
        public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            DateTime dt;
            if (reader.TryGetDateTime(out dt))
            {
                return dt;
            }
            throw new JsonException();
            //return DateTime.Parse(reader.GetString());
        }

        public override void Write(Utf8JsonWriter writer, DateTime? dateTimeValue, JsonSerializerOptions options)
        {
            if (dateTimeValue != null)
            {
                try
                {
                    // We need to reduce the precision. See issue https://github.com/xpouyat/MK.IO/issues/43
                    // We limit the conversion of DateTime to the format "yyyy-MM-ddTHH:mm:ss.ffZ"
                    writer.WriteStringValue(dateTimeValue.Value.ToString("yyyy-MM-ddTHH:mm:ss.ffZ", CultureInfo.InvariantCulture));
                }
                catch (Exception ex)
                {
                    throw new JsonException(ex.Message);
                }
            }
        }
    }

    internal class CustomDateTimeConverter : JsonConverter<DateTime>
    {

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            DateTime dt;
            if (reader.TryGetDateTime(out dt))
            {
                return dt;
            }
            throw new JsonException();
        }

        public override void Write(Utf8JsonWriter writer, DateTime dateTimeValue, JsonSerializerOptions options)
        {
            try
            {
                // We need to reduce the precision. See issue https://github.com/xpouyat/MK.IO/issues/43
                // We limit the conversion of DateTime to the format "yyyy-MM-ddTHH:mm:ss.ffZ"
                writer.WriteStringValue(dateTimeValue.ToString("yyyy-MM-ddTHH:mm:ss.ffZ", CultureInfo.InvariantCulture));
            }
            catch (Exception ex)
            {
                throw new JsonException(ex.Message);
            }
        }
    }

    internal class CustomTimeSpanConverter : JsonConverter<TimeSpan>
    {
        public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            try
            {
                return XmlConvert.ToTimeSpan(reader.GetString());
            }
            catch (Exception ex)
            {
                throw new JsonException(ex.Message);
            }
        }

        public override void Write(Utf8JsonWriter writer, TimeSpan dateTimeValue, JsonSerializerOptions options)
        {
            try
            {
                writer.WriteStringValue(XmlConvert.ToString(dateTimeValue));
            }
            catch (Exception ex)
            {
                throw new JsonException(ex.Message);
            }
        }
    }

    internal class CustomTimeSpanNConverter : JsonConverter<TimeSpan?>
    {
        public override TimeSpan? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.GetString() != null)
            {
                try
                {
                    return XmlConvert.ToTimeSpan(reader.GetString());
                }
                catch (Exception ex)
                {
                    throw new JsonException(ex.Message);
                }
            }
            else
            {
                return null;
            }
        }

        public override void Write(Utf8JsonWriter writer, TimeSpan? dateTimeValue, JsonSerializerOptions options)
        {
            if (dateTimeValue != null)
            {
                try
                {
                    writer.WriteStringValue(XmlConvert.ToString(dateTimeValue.Value));
                }
                catch (Exception ex)
                {
                    throw new JsonException(ex.Message);
                }
            }
        }
    }

    /*
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
    */
}