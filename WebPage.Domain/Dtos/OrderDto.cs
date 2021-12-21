using System.Collections.Generic;
using System.Linq;
using WebPage.Domain.Models;

namespace WebPage.Domain.Dtos
{
    public class OrderDto
    {
        public Customer Buyer { get; set; }
        public int TotalPrice;
        public List<ShopItemDto> Items { get; set; }
    }
    
}