using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FactoryBot;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using WebPage.API.Controllers;
using WebPage.DAL.Database;
using WebPage.Domain.Models;
using Xunit;
using Assert = NUnit.Framework.Assert;

namespace Tests
{
    public class ArticleControllerTest 
    {
        private static readonly IEnumerable<Article> TestData = _getTestData();
        private  readonly ArticleController _controller;

        public ArticleControllerTest()
        {
            var unitOfWork = new UnitOfWork(new TestDbContext<Article>().Object);
            _controller = new ArticleController(unitOfWork);
        }

        [Fact]
        public async void Get_returnsAllArticles()
        {

            var result = await _controller.Get();
            Assert.NotNull(result);
            Assert.AreEqual(TestData.Count(),result.Count());

        }
        
        [Fact]
        public async void Get_returnsAnArticle()
        {
            var result = await _controller.Get(TestData.First().Id);
            Assert.NotNull(result);

            Assert.AreEqual(TestData.First().Title,result.Title);
            Assert.AreEqual(TestData.First().Description,result.Description);
        }
        
        [Fact]
        public async void Post_addsToTheDatabaseAnArticle()
        {
            var dummyArticle = new Article
            {
                Description = "This is a dummy article",
                Title = "Dummy article"
            };
            var actionresult = await _controller.Post(dummyArticle);
            var result = actionresult.Result as CreatedResult;
            Assert.NotNull(result);

            var resultValue = result.Value as Article;
            Assert.AreEqual(dummyArticle.Description,resultValue.Description);
            Assert.AreEqual(dummyArticle.Title,resultValue.Title);
        }
        [Fact]
        public void Delete_deletesAnArticle()
        {
            Assert.Pass();
        }
        [Fact]
        public void Put_updatesAnArticle()
        {
            Assert.Pass();
        }

        private static IEnumerable<Article> _getTestData()
        {
            Bot.Define(x => new Article
                {
                    Description = x.Strings.Any(),
                    Id = x.Strings.Guid(),
                    Title = x.Strings.Any()
                }

            );
            return Bot.BuildSequence<Article>().Take(10).ToList();
        }
    }
}