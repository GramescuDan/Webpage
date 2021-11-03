using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;
using WebPage.Domain.Models;

namespace WebPage.DAL.Database
{
    public class WebDbContext : DbContext
    {
        public System.Data.Entity.DbSet<Article> Articles;

        public WebDbContext(DbContextOptions<WebDbContext> options) : base(options)
        {
        }
    }
}