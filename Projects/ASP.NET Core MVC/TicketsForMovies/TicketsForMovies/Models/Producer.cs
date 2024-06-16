using System.ComponentModel.DataAnnotations;
using TicketsForMovies.Data.Base;

namespace TicketsForMovies.Models
{
    // Define your entity classes
    public class Producer : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Profile Picture is required")]
        [Display(Name = "Profile Picture")]
        public string? ProfilePictureURL { get; set; }
        [Required(ErrorMessage = "Full Name is required")]
        [Display(Name = "Full Name")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Full Name must be between 3 and 50 chars")]
        public string? FullName { get; set; }
        [Required(ErrorMessage = "Biography is required")]
        [Display(Name = "Biography")]
        public string? Bio { get; set; }

        // Relationships
        public List<Movie>? Movies { get; set; }
    }
}
