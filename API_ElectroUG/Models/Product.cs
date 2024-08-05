using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace API_ElectroUG.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public string ProductImg { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [ForeignKey("CategoryId")]

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [Required]
        [ForeignKey("SupplierId")]
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

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
