using EmailBuilder.Common;
using EmailBuilder.Models.Properties;
using Newtonsoft.Json;
using System;


namespace EmailBuilder.Converters
{
    /// <summary>
    /// A custom JSON converter for the <see cref="EbWidth"/> class, enabling serialization and deserialization
    /// of width values for email elements. This converter supports width values in pixels, percent, or both,
    /// as specified by the <see cref="SizeUnit"/> parameter.
    ///
    /// When serializing, it writes the width value as a JSON string. When deserializing, it reads the string
    /// value, validates it according to the allowed coordinate type, and assigns it to an <see cref="EbWidth"/> instance.
    ///
    /// Usage:
    /// - By default, allows both pixel and percent units.
    /// - Can be configured to restrict allowed units via the constructor.
    /// - Throws a <see cref="JsonSerializationException"/> if the JSON token is not a string.
    /// </summary>
    public class WidthConverter : JsonConverter
    {
        private readonly SizeUnit _allowedCoords;

        // default when used via [JsonConverter(typeof(EbWidthJsonConverter))]
        public WidthConverter() : this(SizeUnit.Both) { }

        // used when you pass an argument from the property attribute
        public WidthConverter(SizeUnit allowedCoords) { _allowedCoords = allowedCoords; }

        public override bool CanConvert(Type t) => typeof(EbWidth).IsAssignableFrom(t);

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var w = (EbWidth)value;
            writer.WriteValue(w?.Width);
        }

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            if (reader.TokenType != JsonToken.String)
                throw new JsonSerializationException($"Width must be a JSON string (got {reader.TokenType}).");

            var s = (string)reader.Value;
            var ew = existingValue as EbWidth ?? new EbWidth(_allowedCoords);

            // Triggers your validation against _allowed
            ew.Width = s; 
            return ew;
        }
    }    
 }
