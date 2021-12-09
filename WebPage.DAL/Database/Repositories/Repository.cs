using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebPage.DAL.Abstractions.IRepositories;
using WebPage.Domain.Abstractions;

namespace WebPage.DAL.Database.Repositories
{
    public class Repository<T> : IRepository<T> where T : AbstractModel
    {
        private readonly WebDbContext _context;

        public Repository(WebDbContext context)
        {
            _context = context;
            DbSet = context.Set<T>();
        }

        public DbSet<T> DbSet { get; }

        public virtual async Task<T> AddAsync(T obj)
        {
            obj.Id = Guid.NewGuid().ToString();
            var entity = (await DbSet.AddAsync(obj)).Entity;
            return entity;
        }

        public virtual async Task<IQueryable<T>> GetAsync()
        {
            var list = await DbSet.ToListAsync();
            return list.AsQueryable();
        }

        public async Task<T> GetAsync(Func<T, bool> predicate)
        {
            return await DbSet.FindAsync(predicate);
        }

        public virtual async Task<T> GetAsync(string objId)
        {
            return await DbSet.FindAsync(objId);
        }

        public virtual async Task<T> DeleteAsync(string id)
        {
            var obj = await DbSet.FindAsync(id);

            if (obj == null) return null;

            obj = DbSet.Remove(obj).Entity;

            return obj;
        }
    }
}