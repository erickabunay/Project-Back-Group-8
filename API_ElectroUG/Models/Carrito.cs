using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API_ElectroUG.Models
{
    public class Carrito
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("UsuarioId")]
        public User Usuario { get; set; }
        public int UsuarioId { get; set; }

        public ICollection<Producto> Productos { get; set; }

        [Required]
        [MaxLength(20)]
        public string Estado { get; set; } // Puede ser "enviado" o "pendiente"
    }
}
