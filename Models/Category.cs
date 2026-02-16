using System.ComponentModel.DataAnnotations;

namespace Mission06_Baird.Models
{
    // Represents a movie category/genre in the database
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; }
    }
}
