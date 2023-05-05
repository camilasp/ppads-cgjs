namespace Domain.Entities.DTO
{
    public sealed class MinimalMovieDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public IReadOnlyList<string> Genres { get; set; }

        public string ReleaseDate { get; set; }

        public string PosterPath { get; set; }

        public double VoteAverage { get; set; }
    }
}
