using WebPage.DAL.Abstractions.IRepositories;
using WebPage.Domain.Models;

namespace WebPage.DAL.Database.Repositories
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        public ShoppingCartRepository(WebDbContext context) : base(context)
        {
        }
    }
}