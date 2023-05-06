using Application.Interfaces;
using DM.MovieApi;
using DM.MovieApi.MovieDb.Movies;

namespace Infrastructure.Services
{
    public sealed class MovieDbClient : IMovieClient
    {
        string bearerToken = "eyJhbGciOiJIUzI1NiJ9" +
            ".eyJhdWQiOiI3NjZhNmFlYTVjZDk5NzljNGU5YzQ1NDIxOWIxMDEyMyIsInN1YiI6IjYzZmZkNWFlYzcxNzZkMDBkYjU5Nzg5NyIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ" +
            ".Cpsh-vB7RRQmtVLd025LE0ltkaDKV8AHCEPq57jKK_w";

        private readonly IApiMovieRequest _movieRequest;

        public MovieDbClient()
        {
            MovieDbFactory.RegisterSettings(bearerToken);
            _movieRequest = MovieDbFactory.Create<IApiMovieRequest>().Value;
        }

        public async Task<ICollection<MovieInfo>> GetPopularMoviesAsync(int pageNumber = 1)
        {
            var result = await _movieRequest.GetPopularAsync(pageNumber, "pt-BR");
            return result.Results.ToList();
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var result = await _movieRequest.FindByIdAsync(id);
            return result.Item;
        }
    }
}
