using EmailBuilder.Common;
using EmailBuilder.Converters;
using Newtonsoft.Json;
using System;

namespace EmailBuilder.Models.Properties
{
    /// <summary>
    /// Represents a width property for email elements, supporting both pixel and percentage units.
    /// 
    /// The <see cref="EbWidth"/> class encapsulates width values and their associated unit types (pixels, percent, or both).
    /// It provides validation, formatting, and style helpers for rendering width attributes in HTML and CSS, 
    /// specifically for email template generation.
    /// 
    /// Key Features:
    /// - Supports width values in pixels, percent, or both, as defined by <see cref="SizeUnit"/>.
    /// - Validates width input and extracts numeric values using <see cref="PropertyValidator.ValidateSizeCordinates"/>.
    /// - Provides formatted style strings for use in HTML elements and tables.
    /// - Offers constructors for initializing with unit type and/or width value.
    /// </summary>
    [JsonConverter(typeof(WidthConverter))] // default = Both; property-level can override
    public class EbWidth
    {
        private string _width = string.Empty;
        private string _widthNumericValue = string.Empty;
        private SizeUnit _sizeUnit = SizeUnit.Both;

        public string Width
        {
            get
            {
                if (string.IsNullOrEmpty(_width))
                    _width = "100%";
                return _width;
            }
            set
            {
                // ValidateSizeCoordinates returns true if “value” is valid
                // and spits out the numeric part into out _widthNumericValue
                if (PropertyValidator.ValidateSizeCordinates(value, _sizeUnit, out var numeric))
                {
                    _width = value;
                    _widthNumericValue = numeric;
                }
            }
        }
        public EbWidth() : this(SizeUnit.Both) { }

        public EbWidth(SizeUnit sizeUnit)
        {
            _sizeUnit = sizeUnit;
        }

        public EbWidth(string width, SizeUnit sizeUnit)
        {
            _width = width;
            _sizeUnit = sizeUnit;
        }


        #region element style helpers

        public string WidthNumericValue
        {
            get
            {
                return _widthNumericValue;
            }
        }

        public string WidthStyle
        {
            get
            {
                return $"width:{Width};";
            }
        }
        public string WidthTblStyle
        {
            get
            {
                return $"width:100% !important; max-width:{Width};";
            }
        }

        public string WidthAttr
        {
            get
            {
                return string.IsNullOrEmpty(WidthNumericValue) ? "width='100%'" : $"width='{WidthNumericValue}'";
            }
        }

        #endregion
    }
}