using Microsoft.EntityFrameworkCore;
using WebPage.Domain.Models;

namespace WebPage.DAL.Database
{
    public class WebDbContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public WebDbContext(DbContextOptions<WebDbContext> options) : base(options)
        {
        }
    }
}