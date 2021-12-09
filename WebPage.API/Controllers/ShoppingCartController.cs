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
            if (shoppingCart == null)
            {
                shoppingCart = new ShoppingCart
                {
                    Buyer = buyer,
                    Quantity = 0,
                    TotalPrice = 0,
                    Items = new List<ShopItem>()
                };
                shoppingCart = await UnitOfWork.ShoppingCarts.AddAsync(shoppingCart);
                await UnitOfWork.CompleteAsync();
            }

            return Ok(shoppingCart);
        }

        /*[HttpPost("{id}")]
        public async Task<IActionResult> AddToCart(string id)
        {
            /*var entity = await _unitOfWork.ShopItems.GetAsync(id);
            if (id == null) return BadRequest("No item has this id");
            _cart.TotalPrice += entity.Price;
            _cart.Quantity += 1;
            _cart.Items.Add(_mapper.Map<ShopItem>(entity));
            return Ok();#1#
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFromCart(string id)
        {
            /*var entity = await _unitOfWork.ShopItems.DeleteAsync(id);
            if (id == null) return BadRequest("No item has this id");
            _cart.TotalPrice -= entity.Price;
            _cart.Quantity -= 1;
            _cart.Items.Remove(_mapper.Map<ShopItem>(entity));
            return Ok();#1#
        }*/
    }
}