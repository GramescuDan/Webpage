using System.Collections.Generic;

namespace WebPage.Domain.Models
{
    internal class ShoppingCart
    {
        public Customer Buyer;

        public List<ShopItem> ItemsToBuy;
        public int Id { get; set; }
    }
}