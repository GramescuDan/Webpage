using WebPage.DAL.Abstractions.IRepositories;
using WebPage.Domain.Models;

namespace WebPage.DAL.Database.Repositories
{
    public class CardRepository : Repository<Card>, ICardRepository
    {
        public CardRepository(WebDbContext context) : base(context)
        {
        }
    }
}