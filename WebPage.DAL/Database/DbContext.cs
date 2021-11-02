using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;
using WebPage.Domain.Models;

namespace WebPage.DAL.Database
{
    public class DbContext : IdentityDbContext
    {
        public System.Data.Entity.DbSet<Article> Articles;

        public DbContext(DbContextOptions<DbContext> options) : base(options)
        {
        }
    }
}