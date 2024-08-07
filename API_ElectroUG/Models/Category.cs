using System.ComponentModel.DataAnnotations;

namespace API_ElectroUG.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public bool IsDisabled { get; set; } = false;
    }
}
