using AutoMapper;
using WebPage.Domain.Dtos;
using WebPage.Domain.Models;

namespace WebPage.API.Profiles
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<Article, ArticleDto>();
        }
    }
}