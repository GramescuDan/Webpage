using System.Threading.Tasks;
using WebPage.DAL.Abstractions.IRepositories;

namespace WebPage.DAL.Abstractions.IConfig
{
    public interface IUnitOfWork
    {
        IArticleRepository Articles { get; }
        IShopItemRepository ShopItems { get; }
        ISubscriberRepository Subscribers { get; }
        IShoppingCartRepository ShoppingCarts { get; }
        ICustomerRepository Customers { get; }

        Task CompleteAsync();
    }
}