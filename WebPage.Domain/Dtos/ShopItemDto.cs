namespace WebPage.Domain.Dtos
{
    public class ShopItemDto
    {
        public string id { get; set; }
        public int Stock { get; set; }
        public int Price { get; set; }
        public string NameItem { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
    }
}