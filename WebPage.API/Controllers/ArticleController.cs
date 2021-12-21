using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebPage.DAL.Abstractions.IConfig;
using WebPage.Domain.Dtos;
using WebPage.Domain.Models;

namespace WebPage.API.Controllers
{
    public class ArticleController :GenericController
    {

        public ArticleController(IUnitOfWork unitOfWork,IMapper mapper):base(mapper,unitOfWork)
        {
        }

        [HttpGet]
        public async Task<ActionResult<List<ArticleDto>>> Get()
        {
            var results = (await UnitOfWork.Articles.GetAsync()).ToList();
            return Ok(Mapper.Map<List<ArticleDto>>(results));
        }

        [HttpGet("{id}")]
        public async Task<ArticleDto> Get(string id)
        {
            var entity = await UnitOfWork.Articles.GetAsync(id);
            return Mapper.Map<ArticleDto>(entity);
        }

        [HttpGet("Faqs")]
        public async Task<ActionResult<IQueryable<ArticleDto>>> GetFaq()
        {
            var result = await UnitOfWork.Articles.GetFaqsAsync();
            if (result == null)
                return Ok(new List<ArticleDto>());
            return Ok(Mapper.Map<List<ArticleDto>>(result));
        }

        [HttpGet("News")]
        public async Task<ActionResult<IQueryable<ArticleDto>>> GetNews()
        {
            var result = await UnitOfWork.Articles.GetNewsAsync();
            if (result == null)
                return Ok(new List<ArticleDto>());
            return Ok(Mapper.Map<List<ArticleDto>>(result));
        }

        [HttpPost]
        public async Task<ActionResult<Article>> Post([FromBody] Article entity)
        {
            entity.Id = Guid.NewGuid().ToString();
            var newentity = await UnitOfWork.Articles.AddAsync(entity);
            await UnitOfWork.CompleteAsync();

            return Created("http://localhost:5000/Article/Get", Mapper.Map<ArticleDto>(newentity));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Article>> Delete(string id)
        {
            var newEntity = await UnitOfWork.Articles.DeleteAsync(id);
            if (newEntity == null)
            {
                return BadRequest("Invalid Id");
            }
            await UnitOfWork.CompleteAsync();
            return Ok(newEntity);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Article>> Put(string id, [FromBody] Article entity)
        {
            var entityToUpdate = await UnitOfWork.Articles.GetAsync(id);
            if (entityToUpdate == null)
            {
                return BadRequest("Invalid Id");
            }

            entityToUpdate.Description = entity.Description;
            entityToUpdate.Title = entity.Title;
            entityToUpdate.Type = entity.Type;
            await UnitOfWork.CompleteAsync();
            return Ok(entityToUpdate);
        }
    }
}