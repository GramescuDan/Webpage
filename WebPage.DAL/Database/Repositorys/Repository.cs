using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebPage.DAL.Abstractions;
using WebPage.DAL.Abstractions.IRepositorys;
using WebPage.Domain.Abstractions;

namespace WebPage.DAL.Database
{
    public class Repository<T> : IRepository<T> where T : AbstractModel
    {
        private readonly WebDbContext _context;
        private DbSet<T> dbSet;

        public Repository(WebDbContext context)
        {
            _context = context;
            dbSet = context.Set<T>();
        }
        
        public async Task<T> AddAsync(T obj)
        {
            obj = (await dbSet.AddAsync(obj)).Entity;
            return obj;
        }
        //de vazut queryable
        public async Task<IEnumerable<T>> GetAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<T> GetAsync(string objId)
        {
            return await dbSet.FindAsync(objId);
        }

        public async Task<T> DeleteAsync(string id)
        {
            var obj = await  dbSet.FindAsync(id);
            
            if (obj == null)
            {return null;}
            
            obj =  dbSet.Remove(obj).Entity;
            
            return obj;
        }
    }
}