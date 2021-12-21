using System.Threading.Tasks;
using WebPage.DAL.Abstractions.IRepositories;

namespace WebPage.DAL.Abstractions.IConfig
{
    public interface IUnitOfWork
    {
        ICardRepository Cards { get; }
        IArticleRepository Articles { get; }
        IShopItemRepository ShopItems { get; }
        ISubscriberRepository Subscribers { get; }
        IShoppingCartRepository ShoppingCarts { get; }
        ICustomerRepository Customers { get; }
        
        IOrderRepository Orders { get; }
        Task CompleteAsync();
    }
}