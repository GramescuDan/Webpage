using System.Collections.Generic;
using NUnit.Framework;
using WebPage.DAL.Database;
using WebPage.DAL.Database.Repositorys;
using WebPage.Domain.Models;

namespace Tests
{
    public class ArticleControllerTest 
    {
        private static readonly IEnumerable<Article> TestData;
        
        [SetUp]
        public void Setup()
        {
            var repository = new Repository<Article>(new TestDbContext<Article>().Object);
            
        }

        [Test]
        public void Get_returnsAllArticles()
        {
            Assert.Pass();
        }
        [Test]
        public void Get_returnsAnArticle()
        {
            Assert.Pass();
        }
        [Test]
        public void Post_returnsAnArticle()
        {
            Assert.Pass();
        }
        [Test]
        public void Delete_returnsAnArticle()
        {
            Assert.Pass();
        }
        [Test]
        public void Put_returnsAnArticle()
        {
            Assert.Pass();
        }
    }
}