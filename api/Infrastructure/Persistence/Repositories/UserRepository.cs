using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Context;

namespace Infrastructure.Persistence.Repositories
{
    public sealed class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context) { }
    }
}
