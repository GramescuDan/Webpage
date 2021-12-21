using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebPage.DAL.Abstractions.IConfig;
using WebPage.Domain.Models;

namespace WebPage.API.Controllers
{
    public class OrderController : GenericController
    {
        public OrderController(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        [HttpPost("{idCustomer}")]
        public async Task<ActionResult<Order>> Post(string idCustomer)
        {
            var buyer = await UnitOfWork.Customers.GetAsync(idCustomer);
            if (buyer == null)
            {
                return NotFound("This customer does not exist");
            }

            return Ok();
        }
    }
}