using AspNetCoreWebApiTemplate.Domain.Interfaces;
using AspNetCoreWebApiTemplate.Domain.ObjectModel;
using AspNetCoreWebApiTemplate.Infrastructure.ContextConfiguration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCoreWebApiTemplate.Infrastructure.Repository
{
    public class ReadOnlyRepository<T> : IReadOnlyRepository<T> where T : IEntity
    {
        private readonly AspNetCoreWebApiTemplateContext context;
        public ReadOnlyRepository(AspNetCoreWebApiTemplateContext context)
        {
            this.context = context;
        }

        public async Task<T> Find(Guid id)
        {
            return await context.Set<T>().FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<IEnumerable<T>> FindAll()
        {
            return await context.Set<T>().ToListAsync();
        }
    }
}
