using AutoMapper;
using WebPage.Domain.Dtos;
using WebPage.Domain.Models;

namespace WebPage.API.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDto>();
        }
    }
}