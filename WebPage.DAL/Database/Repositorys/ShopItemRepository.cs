using WebPage.DAL.Abstractions.IRepositorys;
using WebPage.Domain.Models;

namespace WebPage.DAL.Database.Repositorys
{
    public class ShopItemRepository: Repository<ShopItem>,IShopItemRepository
    {
        public ShopItemRepository(WebDbContext context) : base(context)
        {
        }
    }
}