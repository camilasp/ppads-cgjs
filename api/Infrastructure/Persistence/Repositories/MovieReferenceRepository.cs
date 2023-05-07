using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Context;
using System.Security.Cryptography.X509Certificates;

namespace Infrastructure.Persistence.Repositories
{
    public sealed class MovieReferenceRepository : Repository<MovieReference>, IMovieReferenceRepository
    {
        public MovieReferenceRepository(AppDbContext context) : base(context) { }
    }
}
