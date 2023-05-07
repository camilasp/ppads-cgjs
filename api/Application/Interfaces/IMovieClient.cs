using DM.MovieApi.MovieDb.Movies;

namespace Application.Interfaces
{
    public interface IMovieClient
    {
        Task<ICollection<MovieInfo>> GetPopularMoviesAsync(int pageNumber = 1);
        Task<Movie> GetMovieByIdAsync(int id);

        Task<ICollection<MovieInfo>> GetRandomMovieByGenrerAsync(int genre);
    }
}
