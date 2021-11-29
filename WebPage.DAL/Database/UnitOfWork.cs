using System;
using System.Threading.Tasks;
using WebPage.DAL.Abstractions.IConfig;
using WebPage.DAL.Abstractions.IRepositorys;
using WebPage.DAL.Database.Repositorys;
using WebPage.Domain.Models.SendGrid;

namespace WebPage.DAL.Database
{
    public class UnitOfWork: IUnitOfWork,IDisposable
    {
        private readonly WebDbContext _context;
        public IArticleRepository Articles { get; private set; }
        public IShopItemRepository ShopItems { get; private set; }
        public ISubscriberRepository Subscribers { get; private set; }

        public UnitOfWork(WebDbContext context)
        {
            _context = context;
            Articles = new ArticleRepository(_context);
            ShopItems = new ShopItemRepository(_context);
            Subscribers = new SubscriberRepository(_context);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
        
        public  void Dispose()
        { 
            _context.Dispose();
        }
        
    }
}