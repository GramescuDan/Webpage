using System.Threading.Tasks;
using WebPage.DAL.Abstractions.IRepositorys;

namespace WebPage.DAL.Abstractions.IConfig
{
    public interface IUnitOfWork
    {
        IArticleRepository Articles { get; }
        IShopItemRepository ShopItems { get; }
        ISubscriberRepository Subscribers { get; }

        Task CompleteAsync();
    }
    
}