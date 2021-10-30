using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPage.Domain.Models
{
    class Customer
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string email { get; set; }
        public string PhoneNr { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string Postalcode { get; set; }
        public Card card { get; set; }

    }
}
