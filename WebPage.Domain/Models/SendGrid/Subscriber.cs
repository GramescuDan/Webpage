using System.ComponentModel.DataAnnotations;
using WebPage.Domain.Abstractions;

namespace WebPage.Domain.Models.SendGrid
{
    public class Subscriber:AbstractModel
    {
        [EmailAddress]
        public string Email { get; set; }
    }
}