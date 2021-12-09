using WebPage.DAL.Abstractions.IRepositories;
using WebPage.Domain.Models;

namespace WebPage.DAL.Database.Repositories
{
    public class ShopItemRepository : Repository<ShopItem>, IShopItemRepository
    {
        public ShopItemRepository(WebDbContext context) : base(context)
        {
        }
    }
}