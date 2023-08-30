using System.ComponentModel.DataAnnotations;

namespace D_KSRTC.Models
{
    public class LocationDetails
    {
        [Key]
        public int LocationId { get; set; }

        [Required]
        public string LocationName { get; set; } = string.Empty;
    }
}
