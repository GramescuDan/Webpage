using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebPage.DAL.Abstractions.IConfig;
using WebPage.Domain.Models;

namespace WebPage.API.Controllers
{
    public class ShoppingCartController : GenericController
    {

        public ShoppingCartController(IMapper mapper, IUnitOfWork unitOfWork):base(mapper,unitOfWork)
        {
        }

        [HttpGet]
        public async Task<ActionResult<ShoppingCart>> Get(string customerId)
        {
            var buyer = await UnitOfWork.Customers.GetAsync(customerId);
            if (buyer == null)
            {
                return BadRequest("BUYER IS NULL!");
            }
            //.ThenInclude(buyer=>buyer.Card)
            var queryable = UnitOfWork.ShoppingCarts.DbSet.Include(cart => cart.Buyer).Include(cart=>cart.Items);
            var shoppingCart = await queryable.FirstOrDefaultAsync(cart => cart.Buyer.Id == customerId);
            if (shoppingCart is null)
            {
                return NotFound("Missing ShoppingCart!");
            }

            return Ok(shoppingCart);
        }

        [HttpPost("{customerId}")]
        public async Task<ActionResult<ShoppingCart>> Post(string customerId, string shopItemId)
        {
            var buyer = await UnitOfWork.Customers.GetAsync(customerId);
            if (buyer == null)
            {
                return BadRequest("BUYER IS NULL!");
            }

            //.ThenInclude(buyer=>buyer.Card)
            var queryable = UnitOfWork.ShoppingCarts.DbSet.Include(cart => cart.Buyer).Include(cart => cart.Items);
            var shoppingCart = await queryable.FirstOrDefaultAsync(cart => cart.Buyer.Id == customerId);
            if (shoppingCart is null)
            {
                return NotFound("Missing ShoppingCart!");
            }

            var shopitem = await UnitOfWork.ShopItems.GetAsync(shopItemId);
            if (shopitem is null)
            {
                return NotFound("Missing ShopItem!");
            }
            shoppingCart.Items.Add(shopitem);
            await UnitOfWork.CompleteAsync();
            return Ok(await queryable.FirstOrDefaultAsync(cart =>cart.Id == shoppingCart.Id));
        }

    }
}