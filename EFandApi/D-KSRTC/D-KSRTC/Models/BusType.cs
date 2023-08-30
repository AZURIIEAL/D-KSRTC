using System.ComponentModel.DataAnnotations;

namespace D_KSRTC.Models
{
    public class BusType
    {
        [Key]
        public int TypeId { get; set; }

        [Required]
        public string TypeName { get; set; } = string.Empty;

        [Required]
        public float PDF { get; set; }
    }
}
