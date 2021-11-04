using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;
using WebPage.Domain.Models;

namespace WebPage.DAL.Database
{
    public class WebDbContext : DbContext
    {

        public WebDbContext(DbContextOptions<WebDbContext> options) : base(options)
        {
        }
        
        public DbSet<Article> Articles { get; set; }
    }
}