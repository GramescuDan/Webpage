using Microsoft.EntityFrameworkCore;
using WebPage.Domain.Models;
using WebPage.Domain.Models.SendGrid;

namespace WebPage.DAL.Database
{
    public class WebDbContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<ShopItem> ShopItems { get; set; }
        public WebDbContext(DbContextOptions<WebDbContext> options) : base(options)
        {
        }
    }
}