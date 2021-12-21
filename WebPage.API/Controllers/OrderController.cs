using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebPage.DAL.Abstractions.IConfig;
using WebPage.Domain.Dtos;
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

            var queriable = UnitOfWork.ShoppingCarts.DbSet.Include(cart => cart.Buyer).Include(cart => cart.Items);
            var shoppingCart = await queriable.FirstOrDefaultAsync(cart => cart.Buyer.Id == buyer.Id);
            if (shoppingCart == null)
            {
                return BadRequest("Something went wrong, The shopping Cart does npt exist");
            }

            var neworder = new Order
            {
                Buyer = buyer,
                Items = new List<ShopItem>()
            };
            
            foreach (var item in shoppingCart.Items)
            {
                item.Stock--;
                neworder.Items.Add(item);
                shoppingCart.Items.Remove(item);
            }
            await UnitOfWork.CompleteAsync();
            
            return Ok(Mapper.Map<OrderDto>(neworder));
        }
    }
}