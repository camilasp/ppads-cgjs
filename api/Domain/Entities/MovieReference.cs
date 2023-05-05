using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public sealed class MovieReference
    {
        [Key]
        public Guid Id { get; set; }

        public int MovieId { get; set; }

        [ForeignKey("Users")]
        public Guid UserId { get; set; }
        public User? User { get; set; }
    }
}
