using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace D_KSRTC.Models
{
    public class Payment
    {
        [Key]public int PaymentId { get; set; }

         public int BookingId { get; set; }

        [ForeignKey("BookingId")]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Booking? Booking { get; set; }

        [Required] public float Amount { get; set; }

        [Required] public DateTime PaymentDate { get; set; }

        [Required][MaxLength(50)]public string PaymentStatus { get; set; }=string.Empty;
    }
}
