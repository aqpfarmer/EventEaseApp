using System.ComponentModel.DataAnnotations;

namespace EventEaseApp.Models
{
    public class Attendee
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public required string Name { get; set; }

        [Required]
        [StringLength(200)]
        public required string Address { get; set; }

        [Required]
        [Phone]
        public required string Phone { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        [StringLength(100)]
        public required string Country { get; set; }

        [Required]
        public int[] EventIds { get; set; } = Array.Empty<int>();
    }
}