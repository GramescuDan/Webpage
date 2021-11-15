using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebPage.DAL.Abstractions.IRepositorys;
using WebPage.Domain.Abstractions;

namespace WebPage.DAL.Database.Repositorys
{
    public class Repository<T> : IRepository<T> where T : AbstractModel
    {
        private readonly WebDbContext _context;
        protected readonly DbSet<T> DbSet;

        public Repository(WebDbContext context)
        {
            _context = context;
            DbSet = context.Set<T>();
        }
        
        public virtual async Task<T> AddAsync(T obj)
        {
            var entity = (await DbSet.AddAsync(obj)).Entity;
            return entity;
        }
        //de vazut queryable
        public virtual async Task<IEnumerable<T>> GetAsync()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task<T> GetAsync(string objId)
        {
            return await DbSet.FindAsync(objId);
        }

        public virtual async Task<T> DeleteAsync(string id)
        {
            var obj = await  DbSet.FindAsync(id);
            
            if (obj == null)
            {return null;}
            
            obj =  DbSet.Remove(obj).Entity;
            
            return obj;
        }
    }
}