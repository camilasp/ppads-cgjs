using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> CheckUserCredentialsAsync(string email, string password);
        Task<bool> HasUserWithEmailAsync(string email);
        void UpdateUserMovieListAsync(User user);
    }
}
