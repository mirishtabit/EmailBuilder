using EmailBuilder.Common;
using System;

namespace EmailBuilder.Models.Properties
{
    
    //public class EbWidth
    //{
    //    private string _width = string.Empty;
    //    private string _widthNumericValue = string.Empty;
    //    private SizeUnit _sizeUnit = SizeUnit.Both;

    //    public virtual string Width
    //    {
    //        get
    //        {
    //            if (string.IsNullOrEmpty(_width))
    //                _width = "100%";
    //            return _width;
    //        }
    //        set
    //        {
    //            // ValidateSizeCoordinates returns true if “value” is valid
    //            // and spits out the numeric part into out _widthNumericValue
    //            if (PropertyValidator.ValidateSizeCordinates(value, _sizeUnit, out var numeric))
    //            {
    //                _width = value;
    //                _widthNumericValue = numeric;
    //            }
    //        }
    //    }

    //    public EbWidth(SizeUnit sizeUnit)
    //    {
    //        _sizeUnit = sizeUnit;
    //    }

    //    public EbWidth(string width, SizeUnit sizeUnit)
    //    {
    //        _width = width;
    //        _sizeUnit = sizeUnit;
    //    }


    //    #region element style helpers

    //    public string WidthNumericValue
    //    {
    //        get
    //        {
    //            return _widthNumericValue;
    //        }
    //    }

    //    public string WidthStyle
    //    {
    //        get
    //        {
    //            return $"width:{Width};";
    //        }
    //    }
    //    public string WidthTblStyle
    //    {
    //        get
    //        {
    //            return $"width:100% !important; max-width:{Width};";
    //        }
    //    }

    //    public string WidthAttr
    //    {
    //        get
    //        {
    //            return string.IsNullOrEmpty(WidthNumericValue) ? "width='100%'" : $"width='{WidthNumericValue}'";
    //        }
    //    }

    //    #endregion
    //}
}