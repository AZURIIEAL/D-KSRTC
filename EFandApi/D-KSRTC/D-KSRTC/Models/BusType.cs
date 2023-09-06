using System.ComponentModel.DataAnnotations;

namespace D_KSRTC.Models
{
    public class BusType
    {
        [Key]
        public int TypeId { get; set; }

        [Required]
        [MaxLength(100)]
        public string TypeName { get; set; } = string.Empty;

        [Required]
        public float PDF { get; set; }

        public virtual List<BusTypeCategory> BusTypeCategories { get; set; } = new();

    }
}
