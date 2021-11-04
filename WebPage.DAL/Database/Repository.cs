using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebPage.DAL.Abstractions;
using WebPage.Domain.Abstractions;

namespace WebPage.DAL.Database
{
    public class Repository<T> : IRepository<T> where T : AbstractModel
    {
        private readonly WebDbContext _context;
        private DbSet<T> _dbSet;

        public Repository(WebDbContext context)
        {
            _context = context;
        }

        public DbSet<T> DbSet => _dbSet ??= _context.Set<T>();
        private Task<int> Save => _context.SaveChangesAsync();
        
        public async Task<T> AddAsync(T obj)
        {
            obj.Id = Guid.NewGuid().ToString();

            obj = (await DbSet.AddAsync(obj)).Entity;
            await Save;
            return obj;
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<T> GetAsync(string objId)
        {
            return await DbSet.FirstOrDefaultAsync(obj=> obj.Id == objId);
        }

        public async Task<T> DeleteAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<T>> DeleteAsync(IEnumerable<string> ids)
        {
            throw new System.NotImplementedException();
        }
    }
}