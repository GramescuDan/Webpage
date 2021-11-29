using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebPage.DAL.Abstractions.IConfig;
using WebPage.Domain.Models.SendGrid;

namespace WebPage.Infrastructure.SendGrid
{
    public sealed class Client
    {
        private readonly IUnitOfWork _unitOfWork;
    
        public Client(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Send()
        {
            
        }

        public async Task<Email> Compose(string subject,string plaintextcontent,string htmlContent)
        {
            var emailtosend = new Email(subject,plaintextcontent,htmlContent);
            return emailtosend;
        }

        private async Task<List<Subscriber>> Get()
        {
            return (await _unitOfWork.Subscribers.GetAsync()).ToList();
        }
    }
}