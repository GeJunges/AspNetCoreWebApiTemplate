using AspNetCoreWebApiTemplate.Domain.Interfaces;
using AspNetCoreWebApiTemplate.Domain.ObjectModel;
using AspNetCoreWebApiTemplate.Infrastructure.ContextConfiguration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCoreWebApiTemplate.Infrastructure.Repository
{
    public class WritingRepository<T> : IWritingRepository<T> where T : IEntity
    {
        private readonly AspNetCoreWebApiTemplateContext context;

        public WritingRepository(AspNetCoreWebApiTemplateContext context)
        {
            this.context = context;
        }

        public void Add(T entity)
        {
            context.Set<T>().Add(entity);
        }

        public async Task Add(IEnumerable<T> entities)
        {
            await context.Set<T>().AddRangeAsync(entities);
        }

        public void Update(T entity)
        {
            context.Set<T>().Update(entity);
        }

        public void Remove(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public void Remove(IEnumerable<T> entities)
        {
            context.Set<T>().RemoveRange(entities);
        }
    }
}
