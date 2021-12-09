using System.Collections.Generic;
using WebPage.Domain.Models;

namespace WebPage.Domain.Dtos
{
    public class ShoppingCartDto
    {
        public Customer Buyer { get; set; }
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }

        public List<ShopItemDto> Items { get; set; }
    }
}