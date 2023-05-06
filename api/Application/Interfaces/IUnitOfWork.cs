using Application.Interfaces.Repositories;

namespace Application.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IMovieReferenceRepository MovieReferenceRepository { get; }
        Task Commit();
    }
}
