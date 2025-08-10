using Newtonsoft.Json.Linq;
using System;
using System.Text.RegularExpressions;

namespace EmailBuilder.Common
{
    public enum SizeUnit
    {
        PX,
        Percent,
        Both
    }

    public static class PropertyValidator
    {
        /// <summary>
        /// Validates if a string is a valid CSS size (px or %) for the specified unit. Returns true and outputs the numeric value if valid.
        /// </summary>
        /// <param name="value">CSS size string (e.g., "120px", "80%").</param>
        /// <param name="sizeUnit">Allowed unit(s): PX, Percent, or Both.</param>
        /// <param name="widthNumericValue">Outputs the numeric value if valid.</param>
        /// <returns>True if valid; otherwise, false.</returns>
        public static bool ValidateSizeCordinates(string value, SizeUnit sizeUnit, out string widthNumericValue)
        {
             string unitRegex = SizeUnitRegex(sizeUnit);

             widthNumericValue = string.Empty; // Corrected the variable declaration

            if (string.IsNullOrEmpty(value)) return false;

            var match = Regex.Match(value.Trim(), unitRegex);
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
            return false; 
        }

        private static string SizeUnitRegex(SizeUnit sizeUnit)
        {
            switch (sizeUnit)
            {
                case SizeUnit.PX:
                    return @"^(\d+(?:\.\d+)?)(px)$";
                case SizeUnit.Percent:
                    return @"^(\d+(?:\.\d+)?)(%)$";
                case SizeUnit.Both:
                    return @"^(\d+(?:\.\d+)?)(px|%)$";
                default:
                    throw new ArgumentException("Invalid size unit specified.");
            }
            
        }
    }
}
