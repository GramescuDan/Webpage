using System;
using System.Threading.Tasks;
using WebPage.DAL.Abstractions.IConfig;
using WebPage.DAL.Abstractions.IRepositorys;

namespace WebPage.DAL.Database
{
    public class UnitOfWork: IUnitOfWork,IDisposable
    {
        private readonly WebDbContext _context;
        public IArticleRepository Articles { get; private set; }

        public UnitOfWork(WebDbContext context)
        {
            _context = context;
            Articles = new ArticleRepository(context);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
        
        public  void Dispose()
        { 
            _context.Dispose();
        }
        
    }
}