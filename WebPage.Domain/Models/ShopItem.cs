using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebPage.Domain.Abstractions;

namespace WebPage.Domain.Models
{
    public class ShopItem : AbstractModel
    {
        [Range(0, 9999)] public int Stock { get; set; }

        [Range(0, 9999)] public int Price { get; set; }

        public string NameItem { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }

        public ICollection<ShoppingCart> Carts { get; set; }
    }
}