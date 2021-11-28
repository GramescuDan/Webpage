using System.ComponentModel.DataAnnotations;
using WebPage.Domain.Abstractions;
using WebPage.Domain.Enums;

namespace WebPage.Domain.Models
{
    public class Article : AbstractModel
    {
        [Required]
        public ArticleEnum Type { get; set; }
        
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
    