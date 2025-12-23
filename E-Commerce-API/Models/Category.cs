using System.ComponentModel.DataAnnotations;

namespace E_Commerce_API.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public DateTime CreatedAt { get; set; }
    }
}
