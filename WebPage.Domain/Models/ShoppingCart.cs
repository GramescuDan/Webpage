using System.Collections.Generic;
using WebPage.Domain_good.Abstractions;

namespace WebPage.Domain.Models
{
    public class ShoppingCart : AbstractModel
    {
        public Customer Buyer;

        public List<ShopItem> ItemsToBuy;
    }
}