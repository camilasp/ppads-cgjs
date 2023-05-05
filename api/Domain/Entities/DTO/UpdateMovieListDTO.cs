namespace Domain.Entities.DTO
{
    public sealed class UpdateMovieListDTO
    {
        public Guid UserId { get; set; }
        public bool Favorite { get; set; }
        public int MovieId { get; set; }
    }
}
