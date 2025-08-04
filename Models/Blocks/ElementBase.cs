using EmailBuilder.Common;
using EmailBuilder.Converters;
using EmailBuilder.Models.Configurations;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace EmailBuilder.Models.Blocks
{
    /// <summary>
    /// Abstract base class representing an HTML element.
    /// All element classes should inherit from this class.
    /// </summary>

    [JsonConverter(typeof(ElementConverter))]
    public abstract class ElementBase
    {

        /// <summary>
        /// The type of element as received from the client (e.g., Text, Image, etc.)."
        /// </summary>
        public ClientElementType Type { get; set; }
        public ConfigurationBase Configuration { get; set; } = new ConfigurationBase();
        public List<ElementBase> Objects { get; set; }

       
        protected string ElementTagName
        {
            get { return GetHtmlElementTag(); }
        }
        private string GetHtmlElementTag()
        {
            switch (Type)
            {
                case ClientElementType.Layout:
                case ClientElementType.Section:
                    return "table";
                case ClientElementType.Image:
                    return "img";
                case ClientElementType.Text:
                    return "div";

                default:
                    return "div"; 
            }
        }

        #region Html generator properties

        private string _outerHtml = string.Empty;
        private string _innerHtml = string.Empty;
        
        public string OuterHtml
        {
            get { return _outerHtml; }
        }

        public string InnerHtml
        {
            get { return _innerHtml; }
           
        }

        #endregion

        /// <summary>
        /// Base constructor. Calls Initialize and generates the initial HTML.
        public ElementBase()
        { }

        /// <summary>
        /// Generates the HTML representation of the element.
        /// Each inherited element can implement a different GenerateOuterHtml function
        /// </summary>
        /// <param name="innerHtml"></param>
        public virtual string RenderElementHtml(string innerHtml = "")
        {
            string elemStr = string.Empty;
            elemStr = RenderContainer(innerHtml);

            /// Critical - > those rows populate the InnerHtml and the OuterHtml into the Element
            _innerHtml = innerHtml;
            _outerHtml = RenderOuterElementHtml(elemStr);

            return _outerHtml;
        }

        /// <summary>
        /// Renders the custom Html tag. 
        /// </summary>
        /// <param name="innerHtml"></param>
        /// <returns>Html result</returns>
        protected abstract string RenderContainer(string innerHtml);


        /// <summary>
        /// Renders the custom outerHtml. 
        /// </summary>
        /// <param name="elemStr"></param>
        /// <returns>Html result</returns>
        protected abstract string RenderOuterElementHtml(string elemStr);
       

        
    }
}
