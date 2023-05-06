using Application.Interfaces;
using Application.Interfaces.Repositories;
using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.Repositories;

namespace Infrastructure.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private UserRepository _userRepository;
        private MovieReferenceRepository _movieReferenceRepository;

        public AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IUserRepository UserRepository
        {
            get
            {
                return _userRepository = _userRepository ?? new UserRepository(_context);
            }
        }

        public IMovieReferenceRepository MovieReferenceRepository
        {
            get
            {
                return _movieReferenceRepository = _movieReferenceRepository ?? new MovieReferenceRepository(_context);
            }
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
