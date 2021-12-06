using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPage.Domain.Models;

namespace WebPage.DAL.Abstractions.IRepositorys
{
    public interface IArticleRepository:IRepository<Article>
    {
        Task<List<Article>> GetFaqsAsync();
        Task<List<Article>> GetNewsAsync();
    }
}