using WebPage.Domain_good.Abstractions;

namespace WebPage.Domain.Models
{
    public class Article : AbstractModel
    {
        public enum Type
        {
            Faq,
            NewsArticle
        }

        public string Title { get; set; }
        public string Description { get; set; }
    }
}
    