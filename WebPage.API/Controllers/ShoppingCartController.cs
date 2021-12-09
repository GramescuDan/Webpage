using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebPage.DAL.Abstractions.IConfig;
using WebPage.Domain.Models;

namespace WebPage.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;


        public ShoppingCartController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ShoppingCart> GetShoppingCart(string id)
        {
            var queryable = _unitOfWork.ShoppingCarts.DbSet.Include(cart => cart.Buyer);
            return await queryable.FirstOrDefaultAsync(cart => cart.Buyer.Id == id);
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