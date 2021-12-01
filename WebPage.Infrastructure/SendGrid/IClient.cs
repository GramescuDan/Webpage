using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebPage.Domain.Models.SendGrid;

namespace WebPage.Infrastructure.SendGrid
{
    public interface IClient
    {
        Task Send(ElectronicMailTemplate electronicMailTemplate);
        ElectronicMailTemplate Compose(string subject, string plaintextcontent, string htmlContent);
    }
}