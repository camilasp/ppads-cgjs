using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Persistence.Repositories
{
    public sealed class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context) { }

        public async Task<bool> HasUserWithEmailAsync(string email)
        {
            try
            {
                var user = await Get()
                    .Include(x => x.MovieReferences)
                    .FirstOrDefaultAsync(user => user.Email == email);

                return user != null;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<User> CheckUserCredentialsAsync(string email, string password)
        {
            try
            {
                var user = await Get()
                    .Include(x => x.MovieReferences)
                    .FirstOrDefaultAsync(user => 
                    user.Email == email && user.Password == password);

                return user;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public override async Task<User> GetPredicateAsync(Expression<Func<User, bool>> predicate)
        {
            return await Get()
                .Include(x => x.MovieReferences)
                .SingleOrDefaultAsync(predicate);
        }
    }
}
