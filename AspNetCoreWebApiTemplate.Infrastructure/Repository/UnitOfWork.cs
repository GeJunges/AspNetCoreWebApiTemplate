using AspNetCoreWebApiTemplate.Domain.Interfaces;
using AspNetCoreWebApiTemplate.Domain.ObjectModel;
using AspNetCoreWebApiTemplate.Infrastructure.ContextConfiguration;
using System.Threading.Tasks;

namespace AspNetCoreWebApiTemplate.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AspNetCoreWebApiTemplateContext context;
        private readonly IReadOnlyRepository<User> userReadOnlyRepository;

        private readonly IWritingRepository<User> userWritingRepository;

        public UnitOfWork(AspNetCoreWebApiTemplateContext context)
        {
            this.context = context;
        }

        public IReadOnlyRepository<User> UserReadOnlyRepository => userReadOnlyRepository ?? new ReadOnlyRepository<User>(context);

        public IWritingRepository<User> UserWritingRepository => userWritingRepository ?? new WritingRepository<User>(context);

        public int Complete()
        {
            return context.SaveChanges();
        }

        public async Task<int> CompleteAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}
