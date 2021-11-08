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
            return (await _repository.GetAsync()).ToList();
        }
        
        [HttpGet]
        public async Task<Article> Get(string id)
        {
            return (await _repository.GetAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Article>>> Post(Article entity)
        {
            //de verif daca entity are completate campuri
            
            /*try
            {
                if (entity.Description.Length <= 5)
                {
                  
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("");
                throw;
            }*/
            
            var newEntity = await _repository.AddAsync(entity);
            return Created("Article",newEntity);
        }

        [HttpDelete]
        public async Task<ActionResult<IEnumerable<Article>>> Delete(string id)
        {
            try
            {
                var entity = await _repository.GetAsync(id);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("Article was null",e);
                throw;
            }
            
            var newEntity = await _repository.DeleteAsync(id);
            return Ok(newEntity);
        }

        [HttpPut]
        public async Task<Article> Put(string id)
        {
            
        }
    }
}