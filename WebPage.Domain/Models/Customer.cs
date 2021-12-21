using System.ComponentModel.DataAnnotations;
using WebPage.Domain.Abstractions;

namespace WebPage.Domain.Models
{
    public class Customer : AbstractModel
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string PhoneNr { get; set; }
        
        public string Address { get; set; }
        public string Country { get; set; }
        public string Postalcode { get; set; }
        
        public Card CustomerCard { get; set; }
    }
}