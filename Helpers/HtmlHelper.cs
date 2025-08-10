using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmailBuilder.Helpers
{
    public static class HtmlHelper
    {
        /// <summary>
        /// Parses a CSS style string into a dictionary of property-value pairs.
        /// </summary>
        /// <param name="styleValue"></param>
        /// <param name="styleDict"></param>
        public static Dictionary<string, string> CreateTagStyleDictionary(string styleValue, ref Dictionary<string, string> styleDict)
        {
            if (styleDict == null)
                styleDict = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            if (!string.IsNullOrWhiteSpace(styleValue))
            {
                // Split the raw style text into individual declarations
                var declarations = styleValue.Split(';');

                foreach (var decl in declarations.Reverse())
                {
                    // Skip any empty entries (could happen if the string ends with a semicolon)
                    if (string.IsNullOrWhiteSpace(decl))
                        continue;

                    var parts = decl.Split(new[] { ':' }, 2);

                    // Make sure we got both a property name and a value
                    if (parts.Length != 2)
                        continue;

                    var propertyName = parts[0].Trim();
                    var propertyValue = parts[1].Trim();

                    // Only add if it's not already in the dictionary
                    if (!styleDict.ContainsKey(propertyName))
                    {
                        styleDict[propertyName] = propertyValue;
                    }
                }
            }
            return styleDict;
        }

        /// <summary>
        /// Generates a CSS style string from the specified dictionary of style properties and values.
        /// </summary>
        public static string RenderStyleString(Dictionary<string, string> tagStyleDict)
        {
            var sb = new StringBuilder();
            if (tagStyleDict != null && tagStyleDict.Count > 0)
            {
                foreach (var elem in tagStyleDict)
                {
                    sb.Append($"{elem.Key}:{elem.Value};");
                }
            }
            return sb.ToString();
        }

       
        public static void AddToDictionary(Dictionary<string, string> Dict, string propKey, string propValue)
        {
            if (string.IsNullOrEmpty(propKey) || string.IsNullOrEmpty(propValue))
                return;

            if (!Dict.ContainsKey(propKey))
                Dict.Add(propKey, propValue);

        }
    }
    
}

