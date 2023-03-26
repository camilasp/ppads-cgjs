using Application.Interfaces;
using DM.MovieApi;
using DM.MovieApi.MovieDb.Certifications;
using DM.MovieApi.MovieDb.Movies;

namespace Infrastructure.Services
{
    public sealed class MovieDbClient : IMovieClient
    {
        string bearerToken = "eyJhbGciOiJIUzI1NiJ9" +
            ".eyJhdWQiOiI3NjZhNmFlYTVjZDk5NzljNGU5YzQ1NDIxOWIxMDEyMyIsInN1YiI6IjYzZmZkNWFlYzcxNzZkMDBkYjU5Nzg5NyIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ" +
            ".Cpsh-vB7RRQmtVLd025LE0ltkaDKV8AHCEPq57jKK_w";

        private readonly IApiMovieRequest _movieRequest;
        private readonly IApiMovieRatingRequest _movieRatingRequest;

        public MovieDbClient()
        {
            MovieDbFactory.RegisterSettings(bearerToken);
            _movieRequest = MovieDbFactory.Create<IApiMovieRequest>().Value;
            _movieRatingRequest = MovieDbFactory.Create<IApiMovieRatingRequest>().Value;
        }
    }
}
