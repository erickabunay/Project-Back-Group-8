using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace API_ElectroUG.Models
{
    public class Pedido
    {
        [Key]
        public int PedidoId { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        public List<Product> ElementosPedido { get; set; } = new List<Product>();

        [Required]
        public DateTime FechaPedido { get; set; }

        public decimal Total { get; set; }

        public string Estado { get; set; } = "Pendiente";
    }

    public class ItemPedido
    {
        [Key]
        public int ElementoPedidoId { get; set; }

        [Required]
        [ForeignKey("PedidoId")]
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }

        [Required]
        [ForeignKey("ProductoId")]
        public int ProductoId { get; set; }
        public Product Producto { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Precio { get; set; }
    }
}