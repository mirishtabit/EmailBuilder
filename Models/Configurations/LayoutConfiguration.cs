using EmailBuilder.Common;
using EmailBuilder.Models.Configurations.SubConfiguration;
using EmailBuilder.Models.HtmlProperties;
using EmailBuilder.Models.Properties;
using EmailBuilder.Models.Properties.Spacing;
using HtmlAgilityPack;
using Newtonsoft.Json;
using System;

namespace EmailBuilder.Models.Configurations
{
    /// <summary>
    /// Represents the configuration for the layout of an email template.
    /// </summary>
    public class LayoutConfiguration: ConfigurationBase
    {
        #region element properties

        [JsonProperty(Required = Required.Always)]
        public DefaultTagStyles DefaultTagStyles { get; set; }

        [JsonProperty(Required = Required.Always)]
        public DefaultGeneralStyles DefaultGeneralStyles { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string BodyColor { get; set; } = "transparent";

        [JsonProperty(Required = Required.Always)]
        public EbLayoutSpacing Spacing { get; set; } = new EbLayoutSpacing();

        [JsonProperty(Required = Required.Always)]
        public EbBackgroundImage BackgroundImage { get; set; } = new EbBackgroundImage();

        [JsonProperty("BodyWidth", Required = Required.Always)]
        public override string Width
        {
            get => base.Width;
            set => base.Width = value;
        }

        #endregion

        #region element style helpers

        public string Tbl1Style
        {
            get
            {
                string styles = $"{BackColorStyle(BackgroundColor)} {BackgroundImage.GetHtmlStyle}";
                string attributes = $"{BackColorAttr(BackgroundColor)} {TableMsoAttributes} width=\"100%\" align=\"center\" role=\"presentation\"";
                return $"style=\"{styles}\" {attributes}";
            }
        }

        public string Td1Style
        {
            get
            {
                string styles = $"{Spacing.GetHtmlStyle}";
                string attributes = $"width=\"100%\" align=\"center\"";
                return $"style=\"{styles}\" {attributes}";
             
            }
        }

        public string InnerStyle
        {
            get
            {
                string styles = $"{WidthTblStyle} {BackColorStyle(BodyColor)}";
                string attributes = $"{BackColorAttr(BodyColor)} {WidthAttr} {TableMsoAttributes}";
                return $"style=\"{styles}\" {attributes}";
            }
        }

        #endregion

        public LayoutConfiguration()
        {
        }

        /// <summary>
        /// This method injects the default styles into the body HTML document.
        /// bodyHtml is expected to be the HTML document representing the skeleton of the email.
        /// </summary>
        /// <param name="bodyHtml"></param>
        public void InjectInlineStyle(ref HtmlDocument bodyHtml)
        { 
            DefaultTagStyles.ApplyAsInnerStyle(ref bodyHtml);
            DefaultGeneralStyles.ApplyAsInnerStyle(ref bodyHtml);
        }
    }
}
