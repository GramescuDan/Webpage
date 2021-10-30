using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPage.Domain.Abstractions
{
    class Article
    {
        public int MaxLengthTitle = 0;
        public int MaxLengthDescription = 0;
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
