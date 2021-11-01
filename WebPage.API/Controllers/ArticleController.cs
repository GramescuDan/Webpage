using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPage.Domain.Models;
using WebPage.DAL.Abstractions;

namespace WebPage.API.Controllers
{
    [Route("/api/[controller]")]
    public class ArticleController : Controller
    {
        private readonly IRepository<Article> _repository;
        public ArticleController(IRepository<Article> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Article>>> Get()
        {
            return Ok((await _repository.GetAsync()).ToList);
        }
    }
}
