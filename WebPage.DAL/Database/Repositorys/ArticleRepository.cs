using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebPage.DAL.Abstractions.IRepositorys;
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
                var entity = await dbSet.FindAsync(id);
                return entity;
            }
            catch (NullReferenceException exception)
            {
                Console.WriteLine("The Object was not found!");
                return new Article();
            }
        }
        
        
        
    }
}