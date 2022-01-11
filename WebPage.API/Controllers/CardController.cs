using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebPage.DAL.Abstractions.IConfig;
using WebPage.Domain.Models;

namespace WebPage.API.Controllers
{
    public class CardController: GenericController
    {
        public CardController(IMapper mapper,IUnitOfWork unitOfWork):base(mapper,unitOfWork)
        {
            
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> Post([FromBody] Card card, string CustomerId)
        {
            var entity = await UnitOfWork.Customers.GetAsync(CustomerId);
            if (entity == null)
            {
                return BadRequest("The Id is not valid!");
            }
            entity.CustomerCard = card;
            await UnitOfWork.CompleteAsync();
            return Created($"api/card/{entity.Id}", entity);
        }
    }
}