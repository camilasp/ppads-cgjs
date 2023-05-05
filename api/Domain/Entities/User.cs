using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public sealed class User
    {
        public Guid Id { get; set; } = new Guid();

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }

        public ICollection<MovieReference> MovieReferences { get; set; }
    }
}
