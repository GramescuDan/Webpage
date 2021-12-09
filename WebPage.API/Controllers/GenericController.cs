using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebPage.DAL.Abstractions.IConfig;

namespace WebPage.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenericController :ControllerBase
    {
        protected readonly IMapper Mapper;
        protected readonly IUnitOfWork UnitOfWork;

        public GenericController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }
    }
}