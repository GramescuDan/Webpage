using System.Collections.Generic;
using System.Threading.Tasks;
using WebPage.Domain.Models;

namespace WebPage.DAL.Abstractions.IRepositories
{
    public interface IArticleRepository:IRepository<Article>
    {
        Task<List<Article>> GetFaqsAsync();
        Task<List<Article>> GetNewsAsync();
    }
}