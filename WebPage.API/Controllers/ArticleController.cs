﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebPage.DAL.Abstractions;
using WebPage.Domain.Models;

namespace WebPage.API.Controllers
{
    [Route("/api/[controller]")]
    public class ArticleController : ControllerBase
    {
        private readonly IRepository<Article> _repository;

        public ArticleController(IRepository<Article> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Article>>> Get()
        {
            var result = await _repository.GetAsync();
            return Ok(result.ToList());
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Article>>> Post(Article entity)
        {
            //de verif 
            var newEntity = await _repository.AddAsync(entity);
            return Created("Article",newEntity);
        }

        [HttpDelete]
        public async Task<ActionResult<IEnumerable<Article>>> Delete(string id)
        {

            var newEntity = await _repository.DeleteAsync(id);
            return Ok(newEntity);
        }
    }
}