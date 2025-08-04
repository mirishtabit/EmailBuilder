using EmailBuilder.Models.Blocks;
using EmailBuilder.Models.HtmlObjects;

namespace EmailBuilder.Services.Interfaces
{
    public interface IMainGeneratorService
    {
        void BuildElementClasses();       
        string RenderLayoutHtml(EbLayout layout);
    }
}