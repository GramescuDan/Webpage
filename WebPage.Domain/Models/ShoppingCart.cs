using System.Collections.Generic;
using WebPage.Domain.Abstractions;
using WebPage.Domain.Models;

namespace WebPage.Domain.Models
{
    public class ShoppingCart : AbstractModel
    {
        public Customer Buyer;

        public List<ShopItem> ItemsToBuy;
    }
}