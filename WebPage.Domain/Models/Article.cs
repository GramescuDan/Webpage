using WebPage.Domain.Abstractions;

namespace WebPage.Domain.Models
{
    public class Article : AbstractModel
    {
        //0 is for faq and 1 is for news
        public bool FaqOrNews { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}