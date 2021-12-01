using System.Collections.Generic;
using System.Linq;
using FactoryBot;
using WebPage.API.Controllers;
using WebPage.DAL.Database;
using WebPage.Domain.Models;
using Xunit;
using Xunit.Abstractions;

namespace Tests.ControllerTests
{
    public class ShopItemControllerTest
    {
        private static readonly IEnumerable<ShopItem> TestData = _getTestData();
        private readonly ShopItemController _controller;


        public ShopItemControllerTest(ITestOutputHelper outputHelper)
        {
            var unitOfWork = new UnitOfWork(new TestDbContext<ShopItem>(TestData).Object);
            _controller = new ShopItemController(unitOfWork);
        }
        






        private static IEnumerable<ShopItem> _getTestData()
        {
            Bot.Define(x => new ShopItem
                {
                    Id = x.Guid.ToString(),
                    Stock = x.Integer.Any(0,100),
                 Price = x.Integer.Any(0,100),
                 NameItem = x.Names.FirstName(),
                 Description = x.Strings.Any(),
                 PhotoUrl = x.Strings.Any()
                }
            );
            return Bot.BuildSequence<ShopItem>().Take(10).ToList();
        }
    }
}