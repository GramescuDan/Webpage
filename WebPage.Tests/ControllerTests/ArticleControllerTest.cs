
using System;
using System.Collections.Generic;
using System.Linq;
using FactoryBot;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebPage.API.Controllers;
using WebPage.DAL.Database;
using WebPage.Domain.Enums;
using WebPage.Domain.Models;
using Xunit;
using Xunit.Abstractions;
using Assert = NUnit.Framework.Assert;

namespace Tests.ControllerTests
{
    public class ArticleControllerTest
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private static readonly IEnumerable<Article> TestData = _getTestData();
        private readonly ArticleController _controller;


        public ArticleControllerTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            var unitOfWork = new UnitOfWork(new TestDbContext<Article>(TestData).Object);
            _controller = new ArticleController(unitOfWork);
        }

        [Fact]
        public async void Get_returnsAllArticles()
        {
            var actionResult = await _controller.Get();

            Assert.NotNull(actionResult);

            var result = actionResult.Result as OkObjectResult;
            Assert.NotNull(result);
            Assert.AreEqual(StatusCodes.Status200OK,result.StatusCode);

            var value = result.Value as List<Article>;
            Assert.NotNull(value);
            
            Assert.AreEqual(TestData.Count(), value.Count());
            Assert.AreEqual(TestData, value);
        }

        [Fact]
        public async void Get_returnsAnArticle()
        {
            var result = await _controller.Get(TestData.First().Id);

            Assert.NotNull(result);
            Assert.AreEqual(TestData.First().Title, result.Title);
            Assert.AreEqual(TestData.First().Description, result.Description);
            Assert.AreEqual(TestData.First().Type, result.Type);
        }
        
        [Fact]
        public async void GetFaq_returnsOnlyFaqs()
        {
            var actionResult = await _controller.GetFaq();
            Assert.NotNull(actionResult);

            var result = actionResult.Result as OkObjectResult;
            Assert.NotNull(result);
            Assert.AreEqual(StatusCodes.Status200OK,result.StatusCode);

            var value = result.Value as IQueryable<Article>;
            Assert.NotNull(value);

            var list = value.ToList();
            Assert.NotNull(list);
            Assert.IsFalse(TestData.Count() == list.Count);
        }
        
        [Fact]
        public async void GetFaq_returnsOnlyNews()
        {
            var actionResult = await _controller.GetNews();
            Assert.NotNull(actionResult);

            var result = actionResult.Result as OkObjectResult;
            Assert.NotNull(result);
            Assert.AreEqual(StatusCodes.Status200OK,result.StatusCode);

            var value = result.Value as IQueryable<Article>;
            Assert.NotNull(value);

            var list = value.ToList();
            Assert.NotNull(list);
            Assert.IsFalse(TestData.Count() == list.Count);
        }
        

        [Fact]
        public async void Post_addsToTheDatabaseAnFaqAndAnNewsArticle()
        {
            var dummyArticle = new Article
            {
                Description = "This is a dummy article",
                Title = "Dummy article",
                Type = ArticleEnum.Faq
            };
            
            var dummyArticle2 = new Article
            {
                Description = "This is a second dummy article",
                Title = "Dummy article2",
                Type = ArticleEnum.News
            };
            
            var actionresult = await _controller.Post(dummyArticle);
            var actionresult2 = await _controller.Post(dummyArticle2);
            
            var result = actionresult.Result as CreatedAtActionResult;
            var result2 = actionresult2.Result as CreatedAtActionResult;
            
            
            Assert.NotNull(actionresult);
            Assert.NotNull(actionresult2);
            Assert.NotNull(result);
            Assert.NotNull(result2);

            var valueResult = result.Value as Article;
            var valueResult2 = result2.Value as Article;
            
            Assert.NotNull(valueResult);
            Assert.NotNull(valueResult2);
            
            Assert.AreEqual(dummyArticle.Description,valueResult.Description);
            Assert.AreEqual(dummyArticle.Title,valueResult.Title);
            
            Assert.AreEqual(dummyArticle2.Description,valueResult2.Description);
            Assert.AreEqual(dummyArticle2.Title,valueResult2.Title);
        }
        

        [Fact]
        public async void Delete_deletesAnArticle()
        {
            var dummyArticle = TestData.First();
            var entity = await _controller.Delete(dummyArticle.Id);
            var result = entity.Result as OkObjectResult;
            
            Assert.NotNull(entity);
            Assert.NotNull(result);
            var valueResult = result.Value as Article;
            
            Assert.NotNull(valueResult);
            Assert.AreEqual(dummyArticle.Description,valueResult.Description);
            Assert.AreEqual(dummyArticle.Title,valueResult.Title);

            //Assert.AreNotEqual(cnt,TestData.Count());
        }

        [Fact]
        public async void Put_updatesAnArticle()
        {
            var dummyArticle = TestData.First();
            dummyArticle.Description = "This is a dummy article";
            dummyArticle.Title = "Dummy article";

            var actionResult = await _controller.Put(TestData.First().Id, dummyArticle);
            Assert.NotNull(actionResult);

            var result = actionResult.Result as OkObjectResult;
            Assert.NotNull(result);
            Assert.AreEqual(StatusCodes.Status200OK,result.StatusCode);

            var value = result.Value as Article;
            Assert.NotNull(value);
            Assert.AreEqual(TestData.First().Description, value.Description);
            Assert.AreEqual(TestData.First().Title, value.Title);
            Assert.AreEqual(TestData.First().Type, value.Type);
        }
        
        [Fact]
        public async void Put_returnBadRequestWhenGivingWrongId()
        {
            var dummyArticle = TestData.First();
            dummyArticle.Id = "100";
            dummyArticle.Description = "This is a dummy article";
            dummyArticle.Title = "Dummy article";

            var actionResult = await _controller.Put(TestData.First().Id, dummyArticle);
            Assert.NotNull(actionResult);

            var result = actionResult.Result as OkObjectResult;
            Assert.IsNull(result);

            var secondResult = actionResult.Result as BadRequestResult;
            Assert.NotNull(secondResult);
            Assert.AreEqual(StatusCodes.Status400BadRequest,secondResult.StatusCode);
        }
        
        

        private static IEnumerable<Article> _getTestData()
        {
            Bot.Define(x => new Article
                {
                    Type = x.Enums.Any<ArticleEnum>(),
                    Description = x.Strings.Any(),
                    Id = x.Strings.Guid(),
                    Title = x.Strings.Any()
                }
            );
            return Bot.BuildSequence<Article>().Take(10).ToList();
        }
    }
}