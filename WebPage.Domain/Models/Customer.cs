﻿namespace WebPage.Domain.Models
{
    internal class Customer
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