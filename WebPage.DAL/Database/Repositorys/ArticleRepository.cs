using System.Diagnostics.CodeAnalysis;
using WebPage.DAL.Abstractions.IRepositorys;
using WebPage.Domain.Models;

namespace WebPage.DAL.Database.Repositorys
{
    public class ArticleRepository: Repository<Article>,IArticleRepository
    {
        public ArticleRepository([NotNull] WebDbContext context) : base(context)
        {
        }
    }
}