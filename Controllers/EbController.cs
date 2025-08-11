using EmailBuilder.Common;
using EmailBuilder.Extensions;
using EmailBuilder.Models.Blocks;
using EmailBuilder.Services;
using EmailBuilder.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace EmailBuilder
{
    [RoutePrefix("api/Eb")]
    public class EbController : ApiController
    {
        private readonly IMainGeneratorService _mainGeneratorService;
        private readonly IMailTrapService _mailTrapService;

        public EbController(IMailService MailService,
                            IMailTrapService mailTrapService)
        {
            _mailTrapService = mailTrapService;
        }

        [HttpGet]
        [Route("Index")]
        public IHttpActionResult Index()
        {
            return Ok("EbController Index reached.");
        }

        [HttpGet]
        [Route("BuildExample")]
        /// This endpoint is an example of building the magazin via element classes.
        public IHttpActionResult BuildExample()
        {
            MainGeneratorService _mainGeneratorService = new MainGeneratorService();
            EbLayout layout = _mainGeneratorService.BuildElementClasses();
            if (layout == null)
                return BadRequest("Layout is null, something went wrong.");

            // Render the layout to HTML
            string FinalHtmlResult = layout.GenerateElementsHtml();
            
            if (string.IsNullOrEmpty(FinalHtmlResult))
                return BadRequest("HTML generation failed, the result is empty.");

            var msg = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(FinalHtmlResult, Encoding.UTF8, "text/html")
            };
            return ResponseMessage(msg);
        }


        [HttpGet, Route("RenderHtmlByMail")]
        /// This endpoint renders the HTML from a JSON file and returns it.
        public async Task<IHttpActionResult> RenderHtmlByMail(string fileName,string emailAdress, bool toMail = false)
        {
            var path = System.Web.Hosting.HostingEnvironment.MapPath($"~/Static/MagazinExamples/{fileName}.json");
            var json = System.IO.File.ReadAllText(path);
            Root root;

            try
            {
                root = JsonConvert.DeserializeObject<Root>(json);
            }
            catch(Exception ex)
            {
                var failedType = ex.Data["BlockType"] as string ?? "Unknown";
                throw new Exception($"Error deserializing {failedType}: {ex.Message}");
            }

            if (root == null || root.Layout == null)
                return BadRequest("Invalid JSON structure, or layout dont exists.");

            string FinalHtmlResult = root.Layout.RenderLayoutHtml();

            // Send the HTML result via email
            if (toMail)
            {
                MailService mailSrv = new MailService();
                await mailSrv.SendMailAsync("Hello there", emailAdress , FinalHtmlResult);

                // Send the HTML result via MailTrap - always comented
                //_mailTrapService.SendEmail(FinalHtmlResult);
            }

            var msg = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(FinalHtmlResult, Encoding.UTF8, "text/html")
            };
            return ResponseMessage(msg);
        }
    }
}