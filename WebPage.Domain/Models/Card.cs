using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPage.Domain.Models
{
    class Card
    {
        public string CardNumber { get; set; }
        public string ExpiryDate{ get; set; }
        public string cvv { get; set; }
        public string NameofCard { get; set; }
    }
}
