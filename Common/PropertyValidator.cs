using Newtonsoft.Json.Linq;
using System;
using System.Text.RegularExpressions;

namespace EmailBuilder.Common
{
    public static class PropertyValidator
    {
        /// <summary>
        /// Validates if the given value is a valid CSS coordinate.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <returns>True if the value is a valid CSS coordinate, otherwise false.</returns>
        public static bool ValidateSizeCordinates(string value, out string widthNumericValue)
        {
            widthNumericValue = string.Empty; // Corrected the variable declaration

            if (string.IsNullOrEmpty(value)) return false;

            var match = Regex.Match(value.Trim(), @"^(\d+(?:\.\d+)?)(px|%)$");
            if (match.Success)
            {
                string num = match.Groups[1].Value;
                string unit = match.Groups[2].Value;

                if (Convert.ToInt32(num) > 0) // Corrected variable name
                {
                    switch (unit)
                    {
                        case "px":
                            widthNumericValue = num;
                            return true;  // px value above 0

                        case "%":
                            {
                                if (Convert.ToInt32(num) <= 100) // Corrected variable name
                                {
                                    widthNumericValue = num + "%";
                                    return true;  // Valid percentage
                                }
                                else
                                    return false; // Percentage must be between 0 and 100
                            }
                        default:
                            return false;
                    }
                }
            }
            return false; // Invalid value
        }
    }
}
