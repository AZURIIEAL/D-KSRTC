using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace D_KSRTC.Models
{
    public class Booking
    {
        [Key] public int BookingId { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        [DeleteBehavior(DeleteBehavior.Restrict)] 
        public User? User { get; set; }

        public int BusRouteId { get; set; }

        [ForeignKey("BusRouteId")]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public BusRoute? BusRoute { get; set; }

        [Required] public DateTime BookingDate { get; set; }

        [Required] public DateTime JourneyDate { get; set; }

        [Required] public float TotalAmount { get; set; }

        [Required][MaxLength(50)] public string Status { get; set; } = string.Empty;
    }
}
