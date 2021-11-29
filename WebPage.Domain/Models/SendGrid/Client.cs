using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace WebPage.Domain.Models.SendGrid
{
    public sealed class Client
    {
        public static Client Instance { get; } = new Client();
        public static string apiKey = Environment.GetEnvironmentVariable("");
        private SendGridClient client = new SendGridClient(apiKey);
        private EmailAddress from = new EmailAddress("gramescudan444@gmail.com","Grămescus Team");
        private Client()
        {
            
        }

        //private async Task<List<Subscriber>> getSubscibers()
    }
}