using JetBrains.Annotations;
using WebPage.DAL.Abstractions.IRepositorys;
using WebPage.Domain.Models;

namespace WebPage.DAL.Database
{
    public class ArticleRepository: Repository<Article>,IArticleRepository
    {
        public ArticleRepository([NotNull] WebDbContext context) : base(context)
        {
        }
    }
}