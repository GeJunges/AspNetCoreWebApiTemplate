using AspNetCoreWebApiTemplate.Domain.ObjectModel;
using System.Threading.Tasks;

namespace AspNetCoreWebApiTemplate.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IReadOnlyRepository<User> UserReadOnlyRepository { get; }

        IWritingRepository<User> UserWritingRepository { get; }

        Task<int> CompleteAsync();

        int Complete();
    }
}
