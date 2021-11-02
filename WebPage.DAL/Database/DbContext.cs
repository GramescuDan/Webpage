using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;
using WebPage.Domain.Models;

namespace WebPage.DAL.Database
{
    public class DbContext: IdentityDbContext
    {
        public DbContext(DbContextOptions<DbContext> options): base(options)
        {

        }

        public System.Data.Entity.DbSet<Article> Articles; 
    }
}
