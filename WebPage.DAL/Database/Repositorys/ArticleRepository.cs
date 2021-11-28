using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebPage.DAL.Abstractions.IRepositorys;
using WebPage.Domain.Enums;
using WebPage.Domain.Models;

namespace WebPage.DAL.Database.Repositorys
{
    public class ArticleRepository: Repository<Article>,IArticleRepository
    {
        public ArticleRepository([NotNull] WebDbContext context) : base(context) { }
        
        

        public override async Task<Article> GetAsync(string id)
        {
            try
            {
                var entity = await DbSet.FindAsync(id);
                return entity;
            }
            catch (NullReferenceException exception)
            {
                Console.WriteLine("The Object was not found!");
                return new Article();
            }
        }


        public async Task<IQueryable> GetFaqsAsync()
        {
            var list = await DbSet.ToListAsync();
            return list.AsQueryable().Where(x => x.Type == ArticleEnum.Faq);
        }

        public async Task<IQueryable> GetNewsAsync()
        {
            var list = await DbSet.ToListAsync();
            return list.AsQueryable().Where(x => x.Type == ArticleEnum.News);
        }
    }
}