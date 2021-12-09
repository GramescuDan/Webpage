using AutoMapper;
using WebPage.Domain.Dtos;
using WebPage.Domain.Models;

namespace WebPage.API.Profiles
{
    public class ShoppingCartProfile :Profile
    {
        public ShoppingCartProfile()
        {
            CreateMap<ShoppingCart, ShoppingCartDto>();
        }
    }
}