using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using SendGrid;
using SendGrid.Helpers.Mail;
using WebPage.DAL.Abstractions.IConfig;
using WebPage.DAL.Database;
using WebPage.Domain.Models.SendGrid;

namespace WebPage.Infrastructure.SendGrid
{
    public class Client:IClient
    {
        private readonly IUnitOfWork _unitOfWork;
        //Bad Practice.
        private readonly string _apiKey = "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";
        private readonly SendGridClient _client;
        private readonly EmailAddress _from;
        private readonly IServiceProvider _serviceProvider;

        public Client(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _client = new SendGridClient(_apiKey);
            _from = new EmailAddress("gramescudan444@gmail.com", "Grămescus Team");
        }

        public async Task Send(ElectronicMailTemplate electronicMailTemplate)
        {
            var subscribers = await Get();
            foreach (var subscriber in subscribers)
            {
                var email = new EmailAddress(subscriber.Email);
                var message = MailHelper.CreateSingleEmail(_from, email, electronicMailTemplate.Subject, electronicMailTemplate.PlainTextContent,
                    electronicMailTemplate.HtmlContent);
                var response = await _client.SendEmailAsync(message);
            }
        }

        public ElectronicMailTemplate Compose(string subject,string plaintextcontent,string htmlContent)
        {
            var emailtosend = new ElectronicMailTemplate(subject,plaintextcontent,htmlContent);
            return emailtosend;
        }

        private async Task<List<Subscriber>> Get()
        {
            using var scope = _serviceProvider.CreateScope();
            var unitofwork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
            return (await unitofwork.Subscribers.GetAsync()).ToList();
        }
    }
}