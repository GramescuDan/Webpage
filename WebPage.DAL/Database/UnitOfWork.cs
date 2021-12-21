using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using WebPage.DAL.Abstractions.IConfig;
using WebPage.DAL.Abstractions.IRepositories;
using WebPage.DAL.Database.Repositories;

namespace WebPage.DAL.Database
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly WebDbContext _context;

        public UnitOfWork(WebDbContext context)
        {
            _context = context;
            Cards = new CardRepository(_context);
            Articles = new ArticleRepository(_context);
            ShopItems = new ShopItemRepository(_context);
            Subscribers = new SubscriberRepository(_context);
            ShoppingCarts = new ShoppingCartRepository(_context);
            Customers = new CustomerRepository(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IShoppingCartRepository ShoppingCarts { get; private set; }
        public IArticleRepository Articles { get; }
        public IShopItemRepository ShopItems { get; }
        public ISubscriberRepository Subscribers { get; }
        
        public ICardRepository Cards { get; }
        public ICustomerRepository Customers { get; }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}