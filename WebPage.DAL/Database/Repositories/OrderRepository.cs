using WebPage.DAL.Abstractions.IRepositories;
using WebPage.Domain.Models;

namespace WebPage.DAL.Database.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(WebDbContext context) : base(context)
        {
        }
    }
}