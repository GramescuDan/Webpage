namespace WebPage.Domain.Models
{
    internal class Card
    {
        public string CardNumber { get; set; }
        public string ExpiryDate { get; set; }
        public string Cvv { get; set; }
        public string NameofCard { get; set; }
    }
}