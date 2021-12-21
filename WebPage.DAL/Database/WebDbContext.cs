using Microsoft.EntityFrameworkCore;
using WebPage.Domain.Models;
using WebPage.Domain.Models.SendGrid;

namespace WebPage.DAL.Database
{
    public class WebDbContext : DbContext
    {
        public WebDbContext(DbContextOptions<WebDbContext> options) : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<ShopItem> ShopItems { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}