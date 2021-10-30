using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebPage.Domain.Abstractions;

namespace WebPage.Domain.Models
{
    class Faq : Article
    {
        public Faq()
        {
            this.MaxLengthTitle = 40;
            this.MaxLengthTitle = 600;
        }
    }
}
