using System.ComponentModel.DataAnnotations;

namespace D_KSRTC.Models
{
    public class LocationDetails
    {
        [Key]
        public int LocationId { get; set; }

        [Required]
        [MaxLength(100)]
        public string LocationName { get; set; } = string.Empty;
    }
}
