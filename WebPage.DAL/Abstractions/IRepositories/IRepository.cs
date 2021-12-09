using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebPage.Domain.Abstractions;

namespace WebPage.DAL.Abstractions.IRepositories
{
    public interface IRepository<T> where T : AbstractModel
    {
        DbSet<T> DbSet { get; }
        Task<T> AddAsync([NotNull] T obj);
        Task<IQueryable<T>> GetAsync();
        Task<T> GetAsync(Func<T, bool> predicate);
        Task<T> GetAsync([NotNull] string objId);
        Task<T> DeleteAsync([NotNull] string id);
    }
}