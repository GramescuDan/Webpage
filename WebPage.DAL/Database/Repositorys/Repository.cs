using System;
using System.Collections.Generic;
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
        private DbSet<T> dbset;

        public Repository(WebDbContext context)
        {
            _context = context;
        }
        
        private Task<int> Save => _context.SaveChangesAsync();
        
        public async Task<T> AddAsync(T obj)
        {
            obj.Id = Guid.NewGuid().ToString();

            obj = (await _context.Set<T>().AddAsync(obj)).Entity;
            await Save;
            return obj;
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            return await dbset.ToListAsync();
        }

        public async Task<T> GetAsync(string objId)
        {
            return await dbset.FirstOrDefaultAsync(obj=> obj.Id == objId);
        }

        public async Task<T> DeleteAsync(string id)
        {
            var obj = await  _context.Set.FirstOrDefaultAsync(ent =>ent.Id==id);
            
            if (obj == null)
            {return null;}
            
            obj =  _context.Set<T>().Remove(obj).Entity;
            
            await Save;
            return obj;
        }

        public async Task<IEnumerable<T>> DeleteAsync(IEnumerable<string> ids)
        {
            throw new System.NotImplementedException();
        }
    }
}