using EmailBuilder.Services.Interfaces;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EmailBuilder.Services
{
    /// <summary>
    /// Represents a service for sending emails using an external API.
    /// </summary>
    public class MailService : IMailService
    {
        private static HttpClient httpClient = new HttpClient();
        const string MailUrl = "https://tabitloyaltyafcorev2-int.azurewebsites.net/SendEmail";

        public MailService() { }

        public async Task SendMailAsync(string subject, string recipient, string body)
        {
            // Replace 'using declaration' with explicit 'using statement' to ensure compatibility with C# 7.3
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, MailUrl)
            {
                Content = new StringContent(body, Encoding.UTF8, "application/x-www-form-urlencoded")
            };

            request.Headers.Add("Subject", subject);
            request.Headers.Add("Recipient", recipient);

            var response = await httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();

            // Explicitly dispose of the request object
            request.Dispose();
        }
    }
    

}
