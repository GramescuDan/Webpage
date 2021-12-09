using WebPage.DAL.Abstractions.IRepositories;
using WebPage.Domain.Models;

namespace WebPage.DAL.Database.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(WebDbContext context) : base(context)
        {
        }
    }
}