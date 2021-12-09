using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebPage.DAL.Abstractions.IConfig;
using WebPage.Domain.Models;

namespace WebPage.API.Controllers
{
    public class CustomerController :GenericController
    {

        public CustomerController(IMapper mapper,IUnitOfWork unitOfWork):base(mapper,unitOfWork)
        {
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> Post([FromBody] Customer customer)
        {
            var entity = await UnitOfWork.Customers.AddAsync(customer);
            await UnitOfWork.CompleteAsync();
            return Created($"api/customer/{entity.Id}", entity);
        }
        
    }
}