using System.Collections.Generic;
using System.Linq;
using FactoryBot;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework.Internal;
using WebPage.API.Controllers;
using WebPage.DAL.Database;
using WebPage.Domain.Models;
using Xunit;
using Xunit.Abstractions;
using Assert = NUnit.Framework.Assert;

namespace Tests.ControllerTests
{
    public class ArticleControllerTest
    {
        private static readonly IEnumerable<Article> TestData = _getTestData();
        private readonly ArticleController _controller;


        public ArticleControllerTest(ITestOutputHelper outputHelper)
        {
            var unitOfWork = new UnitOfWork(new TestDbContext<Article>(TestData).Object);
            _controller = new ArticleController(unitOfWork);
        }

        [Fact]
        public async void Get_returnsAllArticles()
        {
            var result = await _controller.Get();

            Assert.NotNull(result);
            Assert.AreEqual(TestData.Count(), result.Count());
            Assert.AreEqual(TestData, result);
        }

        [Fact]
        public async void Get_returnsAnArticle()
        {
            var result = await _controller.Get(TestData.First().Id);

            Assert.NotNull(result);
            Assert.AreEqual(TestData.First().Title, result.Title);
            Assert.AreEqual(TestData.First().Description, result.Description);
        }

        [Fact]
        public async void Post_addsToTheDatabaseAnArticle()
        {
            var cnt = TestData.Count();
            var dummyArticle = new Article
            {
                Description = "This is a dummy article",
                Title = "Dummy article"
            };
            var actionresult = await _controller.Post(dummyArticle);
            var result = actionresult.Result as CreatedAtActionResult;
            
            Assert.NotNull(actionresult);
            Assert.NotNull(result);

            var valueResult = result.Value as Article;
            Assert.AreEqual(dummyArticle.Description,valueResult.Description);
            Assert.AreEqual(dummyArticle.Title,valueResult.Title);
        }

        [Fact]
        public async void Delete_deletesAnArticle()
        {
            var dummyArticle = TestData.First();
            var cnt = TestData.Count();
            var entity = await _controller.Delete(dummyArticle.Id);
            var result = entity.Result as OkObjectResult;
            
            Assert.NotNull(entity);
            Assert.NotNull(result);
            var valueResult = result.Value as Article;
            
            
            //Assert.AreNotEqual(cnt,TestData.Count());
        }

        [Fact]
        public async void Put_updatesAnArticle()
        {
            var dummyArticle = TestData.First();
            dummyArticle.Description = "This is a dummy article";
            dummyArticle.Title = "Dummy article";

            var result = await _controller.Put(TestData.First().Id, dummyArticle);

            Assert.NotNull(result);
            Assert.AreEqual(TestData.First().Description, result.Description);
            Assert.AreEqual(TestData.First().Title, result.Title);
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