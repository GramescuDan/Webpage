using System.Collections.Generic;
using WebPage.Domain.Abstractions;
using WebPage.Domain.Dtos;
using WebPage.Domain.Models;

namespace WebPage.Domain.Models
{
    public class ShoppingCart : AbstractModel
    {
        public Customer Buyer { get; set; }
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }

        public ICollection<ShopItem> Items { get; set; }
        
    }
}