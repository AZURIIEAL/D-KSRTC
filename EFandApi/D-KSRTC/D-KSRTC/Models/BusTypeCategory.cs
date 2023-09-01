using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace D_KSRTC.Models
{
    public class BusTypeCategory
    {
        [Key] public int TCId { get; set; }
         public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public BusCategory? CategoryIdNavigaton { get; set; }
         public int TypeId { get; set; }
        [ForeignKey("TypeId")]
        public BusType? TypeIdNavigaton { get; set; }

    }
}
