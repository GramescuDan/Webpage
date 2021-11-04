using System.Collections.Generic;
using WebPage.Domain.Abstractions;

namespace WebPage.Domain.Models
{
    internal class ShoppingCart : AbstractModel
    {
        public Customer Buyer;

        public List<ShopItem> ItemsToBuy;
    }
}