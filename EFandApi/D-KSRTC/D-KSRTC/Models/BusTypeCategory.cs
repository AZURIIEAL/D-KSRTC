using System.ComponentModel.DataAnnotations;

namespace D_KSRTC.Models
{
    public class BusTypeCategory
    {
        [Key] public int TCId { get; set; }
        [Required] public int CategoryId { get; set; }
        public BusCategory? CategoryIdNavigaton { get; set; }
        [Required] public int TypeId { get; set; }
        public BusType? TypeIdNavigaton { get; set; }

    }
}
