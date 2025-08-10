using EmailBuilder.Models.Blocks;
using EmailBuilder.Models.HtmlObjects;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
namespace EmailBuilder.Converters
{
    /// <summary>
    /// Provides custom JSON serialization and deserialization for layout object and its subclasses.
    /// </summary>
    /// <remarks>Enables polymorphic handling of derived types when reading and writing JSON. During deserialization, it inspects the "Type"
    /// </remarks>
    public class ElementConverter : JsonConverter
    {
        /// <summary>
        /// Indicates whether this converter can convert the specified object type.
        /// </summary>
        /// <param name="objectType"></param>
        /// <returns></returns>
        public override bool CanConvert(Type objectType)
        {
            return typeof(ElementBase).IsAssignableFrom(objectType);
        }

        // ReadJson must return an object, so we create the correct subtype,
        // populate it, and return it.
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // Load the JSON for inspection
            var jObject = JObject.Load(reader);
            ElementBase instance = TypePropertyCheck(objectType, jObject);

            // Populate the instance’s properties from the JSON
            serializer.Populate(jObject.CreateReader(), instance);
          
            return instance;
        }

        /// <summary>
        /// Creates an ElementBase subclass instance based on the "Type" property in the JSON or the provided objectType.
        /// </summary>
        /// <returns>Instance of the appropriate ElementBase subclass.</returns>
        /// <exception cref="NotSupportedException">Thrown if type is unsupported.</exception>
        private static ElementBase TypePropertyCheck(Type objectType, JObject jObject)
        {
            // Try to read "Type" from the JSON
            JToken typeToken = jObject["Type"];
            string typeName = typeToken != null
                ? typeToken.ToString()
                : null;

            // If there's no "Type" field, fall back on the CLR type name
            if (string.IsNullOrEmpty(typeName))
            {
                typeName = objectType.Name;
            }

            // Instantiate the right subclass
            ElementBase instance;
            switch (typeName.ToUpperInvariant())
            {
                case "LAYOUT":
                case "EBLAYOUT":
                    instance = new EbLayout();
                    break;
                case "SECTION":
                case "EBSECTION":
                    instance = new EbSection();
                    break;
                case "IMAGE":
                    instance = new EbImage("100%");
                    break;
                case "TEXT":
                    instance = new EbText();
                    break;
                default:
                    throw new NotSupportedException($"Missing or Unsupported TypeName: {typeName}");
            }

            return instance;
        }

        // WriteJson simply turns the object back into a JObject and writes it out
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var jObject = JObject.FromObject(value, serializer);
            jObject.WriteTo(writer);
        }

    }
}
