using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace D_KSRTC.Models
{
    public class Billing
    {
        [Key]public int BillingId { get; set; }

        public int BookingId { get; set; }

        [ForeignKey("BookingId")]public Booking? Booking { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]public User? User { get; set; }

        [Required]public DateTime BillingDate { get; set; }

        [Required]public float TotalAmount { get; set; }

        [Required][MaxLength(50)]public string PaymentMethod { get; set; } = string.Empty;
    }
}
