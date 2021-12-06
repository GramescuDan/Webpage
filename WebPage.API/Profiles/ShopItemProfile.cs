using AutoMapper;
using WebPage.Domain.Dtos;
using WebPage.Domain.Models;

namespace WebPage.API.Profiles
{
    public class ShopItemProfile: Profile
    {
        public ShopItemProfile()
        {
            CreateMap<ShopItem,ShopItemDto>();
            CreateMap<ShopItemDto,ShopItem>();
        }
    }
}