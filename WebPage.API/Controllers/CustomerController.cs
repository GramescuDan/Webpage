using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var queryable = UnitOfWork.ShoppingCarts.DbSet.Include(cart => cart.Buyer).Include(cart=>cart.Items);
            var shoppingCart = await queryable.FirstOrDefaultAsync(cart => cart.Buyer.Id == entity.Id);
            if (shoppingCart == null)
            {
                shoppingCart = new ShoppingCart
                {
                    Buyer = entity,
                    Items = new List<ShopItem>()
                };
                await UnitOfWork.ShoppingCarts.AddAsync(shoppingCart);
                await UnitOfWork.CompleteAsync();
            }
            
            await UnitOfWork.CompleteAsync();
            
            
            return Created($"api/customer/{entity.Id}", entity);
        }

        [HttpPatch]
        public async Task<ActionResult<Customer>> Patch(string oldCustemer,[FromBody] Customer changedCustomer )
        {
            var oldentity = await UnitOfWork.Customers.GetAsync(oldCustemer);
            if (oldentity == null)
            {
                return NotFound("This customer does not exist!");
            }

            if (changedCustomer == null)
            {
                return BadRequest("The customer is null");
            }
            //very bad practice
            oldentity.Address = changedCustomer.Address;
            oldentity.Age = changedCustomer.Age;
            oldentity.Country = changedCustomer.Country;
            oldentity.Email = changedCustomer.Email;
            oldentity.Name = changedCustomer.Name;
            oldentity.Postalcode = changedCustomer.Postalcode;
            oldentity.Surname = changedCustomer.Surname;
            oldentity.PhoneNr = changedCustomer.PhoneNr;
            oldentity.CustomerCard = changedCustomer.CustomerCard;
            
            await UnitOfWork.CompleteAsync();
            return Ok(oldentity);
        }
        
        [HttpGet("{id}")]

        public async Task<ActionResult<Customer>> Get(string id)
        {
            var result = await UnitOfWork.Customers.GetAsync(id);
            if (result == null)
            {
                return NotFound("This customer does not exist");
            }

            return Ok(result);
        }

    }
}