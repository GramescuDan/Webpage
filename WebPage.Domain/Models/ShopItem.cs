using WebPage.Domain_good.Abstractions;

namespace WebPage.Domain.Models
{
    public class ShopItem : AbstractModel
    {
        public int Stock { get; set; }
        public int Price { get; set; }
        public string NameItem { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
    }
}