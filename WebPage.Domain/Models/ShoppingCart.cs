using System.Collections.Generic;
using System.Data;
using System.Linq;
using WebPage.Domain.Abstractions;
using WebPage.Domain.Dtos;
using WebPage.Domain.Models;

namespace WebPage.Domain.Models
{
    public class ShoppingCart : AbstractModel
    {
        public Customer Buyer { get; set; }
        public int Quantity => Items.Count;
        public int TotalPrice => Items.Aggregate(0, (accumulator, item) => accumulator + item.Price);

        public ICollection<ShopItem> Items { get; set; }
        
    }
}