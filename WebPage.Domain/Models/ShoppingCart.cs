using System.Collections.Generic;
using WebPage.Domain.Abstractions;
using WebPage.Domain.Models;

namespace WebPage.Domain.Models
{
    public class ShoppingCart : AbstractModel
    {
        public Customer Buyer { get; set; }
        public int Quantity { get; set; }

        public List<ShopItem> ItemsToBuy;
    }
}