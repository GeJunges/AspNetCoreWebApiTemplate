using AspNetCoreWebApiTemplate.Domain.ObjectModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCoreWebApiTemplate.Domain.Interfaces
{
    public interface IWritingRepository<T> where T : IEntity
    {
        void Add(T entity);
        Task Add(IEnumerable<T> entities);
        void Update(T entity);
        void Remove(T entity);
        void Remove(IEnumerable<T> entity);
    }
}
