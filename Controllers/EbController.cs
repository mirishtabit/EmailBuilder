using EmailBuilder.Common;
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

        public EbController(IMainGeneratorService mainGeneratorService,
                            IMailService MailService,
                            IMailTrapService mailTrapService)
        {
            _mainGeneratorService = mainGeneratorService;
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
        public IHttpActionResult BuildExample()
        {
            _mainGeneratorService.BuildElementClasses();
            return Ok();
        }

        [HttpGet]
        [Route("SendRenderHtmlByMail")]
        public async Task<IHttpActionResult> SendRenderHtmlByMail([FromUri] string email)
        {
            var path = System.Web.Hosting.HostingEnvironment.MapPath("~/Static/MagazinExamples/Cafe_Largo.json");
            var json = System.IO.File.ReadAllText(path);
            var root = JsonConvert.DeserializeObject<Root>(json);

            if (root == null || root.Layout == null)
                return BadRequest("Invalid JSON structure, or layout dont exists.");

            string FinalHtmlResult = _mainGeneratorService.RenderLayoutHtml(root.Layout);

            MailService mailSrv = new MailService();
            await mailSrv.SendMailAsync("Hello there", email, FinalHtmlResult);

            _mailTrapService.SendEmail(FinalHtmlResult);

            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(FinalHtmlResult, Encoding.UTF8, "text/html");
            return ResponseMessage(response);

        }

        [HttpGet]
        [Route("ShowRenderHtml")]
        public IHttpActionResult ShowRenderHtml(string fileName, bool toMail = false)
        {
            var path = System.Web.Hosting.HostingEnvironment.MapPath($"~/Static/MagazinExamples/{fileName}.json");
            var json = System.IO.File.ReadAllText(path);

            var root = JsonConvert.DeserializeObject<Root>(json);

            if (root == null || root.Layout == null)
                return BadRequest("No layout object.");

            string FinalHtmlResult = _mainGeneratorService.RenderLayoutHtml(root.Layout);

            // Send the HTML result via email
            if (toMail)
            {
                //MailService mailSrv = new MailService();
                //await mailSrv.SendMailAsync("Hello there", "miri.shnaider@tabit.cloud", FinalHtmlResult);
            }

            var msg = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(FinalHtmlResult, Encoding.UTF8, "text/html")
            };
            return ResponseMessage(msg);
        }
    }
}