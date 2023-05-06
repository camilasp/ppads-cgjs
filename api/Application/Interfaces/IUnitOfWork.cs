using Application.Interfaces.Repositories;

namespace Application.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        Task Commit();
    }
}
