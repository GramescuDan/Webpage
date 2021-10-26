using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPage.Domain.Models
{
    class ShopItem
    {
        public int Stock { get; set; }
        public int Price { get; set; }
        public string NameItem { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
    }
}
