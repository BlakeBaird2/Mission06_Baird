using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Baird.Models
{
    // Represents a movie in Joel Hilton's film collection
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }

        // Foreign key to the Category table
        [Required(ErrorMessage = "Category is required")]
        public int CategoryId { get; set; }

        // Navigation property for Category
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Year is required")]
        [Range(1888, 2026, ErrorMessage = "Enter a valid year (1888 or later)")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Director is required")]
        public string? Director { get; set; }

        [Required(ErrorMessage = "Rating is required")]
        public string? Rating { get; set; }

        [Required(ErrorMessage = "Edited is required")]
        public bool Edited { get; set; }

        [Required(ErrorMessage = "Copied to Plex is required")]
        [Display(Name = "Copied to Plex")]
        public bool CopiedToPlex { get; set; }

        public string? LentTo { get; set; }

        [StringLength(25, ErrorMessage = "Notes cannot exceed 25 characters")]
        public string? Notes { get; set; }
    }
}
