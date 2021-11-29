using System.ComponentModel.DataAnnotations;

namespace WebPage.Domain.Models.SendGrid
{
    public class Email
    {
        [Required]
        public string Subject { get; set; } 
        public string PlainTextContent { get; set; }
        public string HtmlContent { get; set; }


        public Email(string subject,string plaintextcontent,string htmlContent)
        {
            Subject = subject;
            PlainTextContent = plaintextcontent;
            HtmlContent = htmlContent;
        }
    }
}