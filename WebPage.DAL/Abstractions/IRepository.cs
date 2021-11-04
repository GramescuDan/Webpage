﻿using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;
using WebPage.Domain.Abstractions;

namespace WebPage.DAL.Abstractions
{
    public interface IRepository<T> where T : AbstractModel
    {
        Task<T> AddAsync([NotNull] T obj);
        Task<IEnumerable<T>> GetAsync();
        Task<T> GetAsync([NotNull] string id);
        Task<T> DeleteAsync([NotNull] string id);
        Task<IEnumerable<T>> DeleteAsync([NotNull] IEnumerable<string> ids);
    }
}