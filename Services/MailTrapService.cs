using EmailBuilder.Services.Interfaces;
using System.Net;
using System.Net.Mail;

namespace EmailBuilder.Services
{
    public class MailTrapService : IMailTrapService
    {
        const string MailTrapApiUrl = "https://mailtrap.io/api/v1/inboxes/{0}/messages";
        private readonly string _apiToken = "7385c360bd47b5368ed111ff2dc76a65";

        //public void SendEmail()
        //{
        //    var client = new RestClient("https://sandbox.api.mailtrap.io/api/send/3909961");
        //    var request = new RestRequest();
        //    request.AddHeader("Authorization", "Bearer " + _apiToken);
        //    request.AddHeader("Content-Type", "application/json");
        //    request.AddParameter("application/json", "{\"from\":{\"email\":\"hello@example.com\",\"name\":\"Mailtrap Test\"},\"to\":[{\"email\":\"miri.shnaider@tabit.cloud\"}],\"subject\":\"You are awesome!\",\"text\":\"Congrats for sending test email with Mailtrap!\",\"category\":\"Integration Test\"}", ParameterType.RequestBody);
        //    var response = client.Post(request);
        //    System.Console.WriteLine(response.Content);
        //}

        public void SendEmail(string body)
        {
            var client = new SmtpClient("sandbox.smtp.mailtrap.io", 2525)
            {
                Credentials = new NetworkCredential("938da7e81cf65f", "4978b400f4da1a"),
                EnableSsl = true
            };

            var mail = new MailMessage
            {
                From = new MailAddress("miri.shnaider@tabit.cloud"),
                Subject = "Hello world",
                Body = body,
                IsBodyHtml = true,                  // ← critical
                BodyEncoding = System.Text.Encoding.UTF8
            };
            mail.To.Add("miri.shnaider@tabit.cloud");

            client.Send(mail);
        }

    }
}
