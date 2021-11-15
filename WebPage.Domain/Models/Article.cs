using WebPage.Domain.Abstractions;

namespace WebPage.Domain.Models
{
    public class Article : AbstractModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
    