using System.ComponentModel.DataAnnotations;

namespace Mission06_Baird.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Year is required")]
        [Range(1888, 2026, ErrorMessage = "Enter a valid year")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Director is required")]
        public string Director { get; set; }

        [Required(ErrorMessage = "Rating is required")]
        public string Rating { get; set; } // Dropdown: G, PG, PG-13, R

        public bool Edited { get; set; } // Yes/No option

        public string? LentTo { get; set; } // Optional

        [StringLength(25, ErrorMessage = "Notes cannot exceed 25 characters")]
        public string? Notes { get; set; } // Optional, Max 25 chars
    }
}