namespace Domain.Entities.DTO
{
    public sealed class UserDTO
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public ICollection<int> Movies { get; set; }
    }
}
