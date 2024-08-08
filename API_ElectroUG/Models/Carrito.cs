using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace API_ElectroUG.Models
{
    public class Carrito
    {
        [Key]
        public int CarritoId { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        public List<Product> ElementosCarrito { get; set; } = new List<Product>();

        public bool EstaCompleto { get; set; } = false;
    }

    public class ItemCarrito
    {
        [Key]
        public int ElementoCarritoId { get; set; }

        [Required]
        [ForeignKey("CarritoId")]
        public int CarritoId { get; set; }
        public Carrito Carrito { get; set; }

        [Required]
        [ForeignKey("ProductoId")]
        public int ProductoId { get; set; }
        public Product Producto { get; set; }

        [Required]
        public int Cantidad { get; set; }
    }
}