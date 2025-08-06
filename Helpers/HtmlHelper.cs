using EmailBuilder.Common;
using EmailBuilder.Models.Configurations;
using HtmlAgilityPack;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmailBuilder.Helpers
{
    public static class HtmlHelper
    {

        public static Dictionary<string, string> CreateTagStyleDictionary(string styleValue,ref Dictionary<string, string> styleDict)
        {
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

        public static string RenderStyleString(Dictionary<string, string> tagStyleDict)
        {
            var sb = new StringBuilder("");
            if (tagStyleDict != null && tagStyleDict.Count > 0)
            {
                foreach (var elem in tagStyleDict)
                {
                    sb.Append($"{elem.Key}:{elem.Value};");
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// Adds a key-value pair to the specified dictionary if the key does not already exist.
        /// </summary>
        /// <remarks>If the specified key already exists in the dictionary, the method does nothing.
        /// Otherwise, the key-value pair is added with the key set to "color" and the value set to <paramref
        /// name="propValue"/>.</remarks>
        /// <param name="Dict">The dictionary to which the key-value pair will be added.</param>
        /// <param name="propKey">The key to check for existence in the dictionary.</param>
        /// <param name="propValue">The value to associate with the key if the key does not exist.</param>
        public static void AddToDictionary(Dictionary<string, string> Dict, string propKey, string propValue)
        {
            if (Dict.ContainsKey(propKey))
                return;
            else
                Dict.Add(propKey, propValue);

        }
    }
    
}

