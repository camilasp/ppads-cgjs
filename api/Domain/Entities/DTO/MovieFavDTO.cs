using DM.MovieApi.MovieDb.Movies;

namespace Domain.Entities.DTO
{
    public sealed class MovieFavDTO
    {
        public bool itsFavorited { get; set; }
        public Movie movie { get; set; }
    }
}
