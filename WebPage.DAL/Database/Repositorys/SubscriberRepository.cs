using WebPage.DAL.Abstractions.IRepositorys;
using WebPage.Domain.Models.SendGrid;

namespace WebPage.DAL.Database.Repositorys
{
    public class SubscriberRepository:Repository<Subscriber>,ISubscriberRepository
    {
        public SubscriberRepository(WebDbContext context) : base(context)
        {
        }
    }
}