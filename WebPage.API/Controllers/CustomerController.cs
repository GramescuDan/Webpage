using System.Collections.Generic;
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
        
    }
}