using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebPage.Domain.Abstractions;

namespace WebPage.DAL.Abstractions
{
    public interface IRepository<T> where T: AbstractModel
    {
        Task<T> AddAsync([NotNull] T obj);
        Task<IEnumerable<T>> GetAsync();
        Task<T> GetAsyncById([NotNull] string id);
        Task<T> DeleteAsync([NotNull] string id);
        Task<IEnumerable<T>> DeleteAsyncByIds([NotNull] IEnumerable<string> ids);
    }
}
