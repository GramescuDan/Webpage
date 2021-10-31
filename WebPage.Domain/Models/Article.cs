using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPage.Domain.Models
{
    class Article
    {
        //0 is for faq and 1 is for news
        public bool FaqOrNews { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
