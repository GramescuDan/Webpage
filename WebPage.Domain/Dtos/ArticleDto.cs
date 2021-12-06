using System.ComponentModel.DataAnnotations;

namespace WebPage.Domain.Dtos
{
    public class ArticleDto
    {
        public string Title { get; set; }
        
        public string Description { get; set; }
    }
}