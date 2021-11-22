using WebPage.Domain.Abstractions;
using WebPage.Domain.Enums;

namespace WebPage.Domain.Models
{
    public class Article : AbstractModel
    {
        public ArticleEnum Type { get; set; }
        
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
    