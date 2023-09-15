using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace D_KSRTC.Models
{
    public class Booking
    {
        [Key] public int BookingId { get; set; }
        public virtual List<Passenger> PassengerNav { get; set; } = null!;

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public User? userMapping { get; set; } = null!;

        public int BusRouteId { get; set; }

        [ForeignKey("BusRouteId")]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public BusRoute? BusRoute { get; set; }

        [Required] public DateTime BookingDate { get; set; }

        [Required] public DateTime JourneyDate { get; set; }

        [Required] public float TotalAmount { get; set; }

        [Required] public string Status { get; set; } = string.Empty;

       
    }
}
