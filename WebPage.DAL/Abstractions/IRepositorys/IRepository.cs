﻿using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using WebPage.Domain.Abstractions;

namespace WebPage.DAL.Abstractions.IRepositorys
{
    public interface IRepository<T> where T : AbstractModel
    {
        Task<T> AddAsync([NotNull] T obj);
        Task<IEnumerable<T>> GetAsync();
        Task<T> GetAsync([NotNull] string objId);
        Task<T> DeleteAsync([NotNull] string id);
        
    }
}