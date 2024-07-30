using System.ComponentModel.DataAnnotations;

namespace API_ElectroUG.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public string ProductImgUrl { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [Required]
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        public int Stock {  get; set; }

        public bool IsDisabled { get; set; } = false;
    }

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
