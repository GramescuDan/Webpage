using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebPage.Domain.Abstractions;

namespace WebPage.Domain.Models
{
    class NewsArticle : Article

    {
        public NewsArticle()
        {
            this.MaxLengthTitle = 40;
            this.MaxLengthDescription = 2000;
        }
    }
}
