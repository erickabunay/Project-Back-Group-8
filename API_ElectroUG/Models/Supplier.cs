using System.ComponentModel.DataAnnotations;

namespace API_ElectroUG.Models
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string BusinessName { get; set; }

        [Required]
        public string TradeName { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string Ruc { get; set; }

        [Required]
        public string CompanyPhone { get; set;}

        [Required]
        public DateTime DateOfEntry { get; set; }

        public bool IsDisabled { get; set; } = false;

    }
}
