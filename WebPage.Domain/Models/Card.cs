using WebPage.Domain.Abstractions;

namespace WebPage.Domain.Models
{
    internal class Card : AbstractModel
    {
        public string CardNumber { get; set; }
        public string ExpiryDate { get; set; }
        public string Cvv { get; set; }
        public string NameofCard { get; set; }
    }
}