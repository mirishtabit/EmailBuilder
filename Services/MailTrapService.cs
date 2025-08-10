using EmailBuilder.Services.Interfaces;
using System.Net;
using System.Net.Mail;

namespace EmailBuilder.Services
{
    /// <summary>
    /// Service for sending emails using MailTrap.
    /// </summary>
    public class MailTrapService : IMailTrapService
    {
        const string MailTrapApiUrl = "https://mailtrap.io/api/v1/inboxes/{0}/messages";
        private readonly string _apiToken = "7385c360bd47b5368ed111ff2dc76a65";

        
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
