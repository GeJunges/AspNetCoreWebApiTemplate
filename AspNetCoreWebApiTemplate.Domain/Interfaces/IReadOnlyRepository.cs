using AspNetCoreWebApiTemplate.Domain.ObjectModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCoreWebApiTemplate.Domain.Interfaces
{
    public interface IReadOnlyRepository<T> where T : IEntity
    {
        Task<T> Find(Guid id);
        Task<IEnumerable<T>> FindAll();
    }
}
