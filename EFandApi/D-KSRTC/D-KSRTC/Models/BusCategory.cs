using System.ComponentModel.DataAnnotations;

namespace D_KSRTC.Models
{
    public class BusCategory
    {
        [Key]public int CategoryId { get; set; }
        [Required]public string CategoryName { get; set; } = string.Empty;
        [Required] public float BaseFare { get; set; }
    }
}
