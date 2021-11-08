using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebPage.DAL.Abstractions;
using WebPage.DAL.Abstractions.IConfig;
using WebPage.DAL.Abstractions.IRepositorys;
using WebPage.Domain.Models;

namespace WebPage.API.Controllers
{
    [Route("/api/[controller]")]
    public class ArticleController : ControllerBase
    {
        private readonly IRepository<Article> _repository;
        private readonly IUnitOfWork _unitOfWork;
        public ArticleController(IRepository<Article> repository,IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<List<Article>> Get()
        {
            return (await _unitOfWork.Articles.GetAsync()).ToList();
        }
        
        [HttpGet]
        public async Task<Article> Get(string id)
        {
            return await _unitOfWork.Articles.GetAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Article>>> Post(Article entity)
        {
                entity.Id = Guid.NewGuid().ToString();
                await _unitOfWork.Articles.AddAsync(entity);
                await _unitOfWork.CompleteAsync();

                return CreatedAtAction("Get", new {entity.Id}, entity);
        }

        [HttpDelete]
        public async Task<ActionResult<IEnumerable<Article>>> Delete(string id)
        {
            try
            {
                var entity = await _unitOfWork.Articles.GetAsync(id);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("Article was null",e);
                throw;
            }
            
            var newEntity = await _unitOfWork.Articles.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
            return Ok(newEntity);
        }

        [HttpPut]
        public async Task<Article> Put(string id,Article entity)
        {
            return null;
        }
    }
}