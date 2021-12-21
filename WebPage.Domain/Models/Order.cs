using System.Collections.Generic;
using System.Linq;
using WebPage.Domain.Abstractions;

namespace WebPage.Domain.Models
{
    public class Order : AbstractModel
    {
        public Customer Buyer { get; set; }
        public int TotalPrice => Items.Aggregate(0, (accumulator, item) => accumulator + item.Price);

        public ICollection<ShopItem> Items { get; set; }
    }
}