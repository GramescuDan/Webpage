using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebPage.DAL.Abstractions.IConfig;
using WebPage.Domain.Models;

namespace WebPage.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ArticleController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ArticleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<List<Article>>> Get()
        {
            return Ok((await _unitOfWork.Articles.GetAsync()).ToList());
        }

        [HttpGet("{id}")]
        public async Task<Article> Get(string id)
        {
            return await _unitOfWork.Articles.GetAsync(id);
        }

        [HttpGet("Faqs")]
        public async Task<ActionResult<IQueryable<Article>>> GetFaq()
        {
            return Ok(await _unitOfWork.Articles.GetFaqsAsync());
        }

        [HttpGet("News")]
        public async Task<ActionResult<IQueryable<Article>>> GetNews()
        {
            return Ok(await _unitOfWork.Articles.GetNewsAsync());
        }

        [HttpPost]
        public async Task<ActionResult<Article>> Post([FromBody] Article entity)
        {
            entity.Id = Guid.NewGuid().ToString();
            var newentity = await _unitOfWork.Articles.AddAsync(entity);
            await _unitOfWork.CompleteAsync();

            return Created("http://localhost:5000/Article/Get", newentity);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Article>> Delete(string id)
        {
            var newEntity = await _unitOfWork.Articles.DeleteAsync(id);
            if (newEntity == null)
            {
                return BadRequest();
            }
            await _unitOfWork.CompleteAsync();
            return Ok(newEntity);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Article>> Put(string id, [FromBody] Article entity)
        {
            var entityToUpdate = await _unitOfWork.Articles.GetAsync(id);
            if (entityToUpdate == null)
            {
                return BadRequest();
            }

            entityToUpdate.Description = entity.Description;
            entityToUpdate.Title = entity.Title;
            entityToUpdate.Type = entity.Type;
            await _unitOfWork.CompleteAsync();
            return Ok(entityToUpdate);
        }
    }
}