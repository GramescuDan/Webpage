using WebPage.DAL.Abstractions.IRepositories;
using WebPage.Domain.Models.SendGrid;

namespace WebPage.DAL.Database.Repositories
{
    public class SubscriberRepository:Repository<Subscriber>,ISubscriberRepository
    {
        public SubscriberRepository(WebDbContext context) : base(context)
        {
        }
    }
}