using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebPage.DAL.Database;
using WebPage.Domain.Abstractions;

namespace Tests
{
    public class TestDbContext<T> where T :  AbstractModel
    {
        public TestDbContext(IEnumerable<T> testData= null)
        {
            var options = new DbContextOptionsBuilder<WebDbContext>()
                .UseInMemoryDatabase(nameof(T) + "-Database-" + Guid.NewGuid())
                .EnableDetailedErrors()
                .EnableSensitiveDataLogging()
                .Options;

            var Object = new WebDbContext(options);

            if (testData == null)
            {
                return;
            }
            Object.Set<T>().AddRange(testData);
            Object.SaveChanges();
        }
        public WebDbContext Object { get; }
    }
}