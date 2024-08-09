using System.ComponentModel.DataAnnotations;

namespace API_ElectroUG.Models
{
    public class Sponsor
    {
        [Key]
        public int SponsorId { get; set; }

        [Required]
        public string SponsorName { get; set; }

        [Required]
        
        public DateTime CreationSponsor { get; set; }

        [Required]
        public string WebsiteUrl { get; set; }

        [Required]
        [StringLength(100)]
        public string ContactEmail { get; set; }

        public bool IsDisabled { get; set; }


    }
}
