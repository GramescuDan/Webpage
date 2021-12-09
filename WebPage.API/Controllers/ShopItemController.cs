using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebPage.DAL.Abstractions.IConfig;
using WebPage.Domain.Dtos;
using WebPage.Domain.Models;


namespace WebPage.API.Controllers
{
    [Route("/api/[controller]")]
    public class ShopItemController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ShopItemController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ShopItemDto>>> Get()
        {
            var result = (await _unitOfWork.ShopItems.GetAsync()).ToList();
            return Ok(_mapper.Map<List<ShopItemDto>>(result));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<ShopItemDto>>> Get(string id)
        {
            var result = await _unitOfWork.ShopItems.GetAsync(id);
            if (result == null)
                return BadRequest("Id invalid");
            return Ok(_mapper.Map<ShopItemDto>(result));
        }

        [HttpPost]
        public async Task<ActionResult<ShopItemDto>> Post([FromBody] ShopItemDto item)
        {
            var newitem = _mapper.Map<ShopItem>(item);
            newitem.Id = Guid.NewGuid().ToString();
            var entity = await _unitOfWork.ShopItems.AddAsync(newitem);
            await _unitOfWork.CompleteAsync();
            return Created("localhost", _mapper.Map<ShopItemDto>(entity));
        }
    }
}