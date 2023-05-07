using Application.Interfaces;
using DM.MovieApi;
using DM.MovieApi.MovieDb.Discover;
using DM.MovieApi.MovieDb.Movies;

namespace Infrastructure.Services
{
    public sealed class MovieDbClient : IMovieClient
    {
        string bearerToken = "eyJhbGciOiJIUzI1NiJ9" +
            ".eyJhdWQiOiI3NjZhNmFlYTVjZDk5NzljNGU5YzQ1NDIxOWIxMDEyMyIsInN1YiI6IjYzZmZkNWFlYzcxNzZkMDBkYjU5Nzg5NyIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ" +
            ".Cpsh-vB7RRQmtVLd025LE0ltkaDKV8AHCEPq57jKK_w";

        private readonly IApiMovieRequest _movieRequest;
        private readonly IApiDiscoverRequest _discoverRequest;

        public MovieDbClient()
        {
            MovieDbFactory.RegisterSettings(bearerToken);
            _movieRequest = MovieDbFactory.Create<IApiMovieRequest>().Value;
            _discoverRequest = MovieDbFactory.Create<IApiDiscoverRequest>().Value;
        }

        public async Task<ICollection<MovieInfo>> GetPopularMoviesAsync(int pageNumber = 1)
        {
            var result = await _movieRequest.GetPopularAsync(pageNumber, "pt-BR");
            return result.Results.ToList();
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var result = await _movieRequest.FindByIdAsync(id, "pt-BR");
            return result.Item;
        }

        public async Task<ICollection<MovieInfo>> GetRandomMovieByGenrerAsync(int genre)
        {
            DiscoverMovieParameterBuilder builder = new DiscoverMovieParameterBuilder();
            builder.WithGenre(genre);

            Random random = new Random();
            var result = await _discoverRequest.DiscoverMoviesAsync(builder, random.Next(1, 151), "pt-BR");
            var movieInfoList = result.Results.OrderBy(x => random.Next()).Distinct().Take(3).ToList();

            return movieInfoList;
        }
    }
}
