using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace D_KSRTC.Models
{
    public class Passenger
    {
        [Key]public int PassengerId { get; set; }

        public int BookingId { get; set; }

        [ForeignKey("BookingId")]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Booking? Booking { get; set; } 

        [Required][MaxLength(100)]public string FirstName { get; set; } = string.Empty;
        [Required][MaxLength(100)]public string LastName { get; set; } = string.Empty;

        [Required] public int Age { get; set; }

        [Required][MaxLength(20)]public string Gender { get; set; } = string.Empty;

        public int SeatId { get; set; }

        [ForeignKey("SeatId")]
        [DeleteBehavior(DeleteBehavior.Restrict)] 
        public Seat? Seat { get; set; }

        [Required][MaxLength(20)]public string PhoneNumber { get; set; } = string.Empty;

        [Required][MaxLength(100)]public string Email { get; set; } = string.Empty;
        [Required][MaxLength(50)] public string Status { get; set; } = string.Empty;
    }
}
