﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace D_KSRTC.Models
{
    public class Seat
    {
        [Key]public int SeatID { get; set; }
        public int BusID { get; set; }

        [ForeignKey("BusID")]public Bus? Bus { get; set; }

        [Required][MaxLength(10)]public string SeatNumber { get; set; } = string.Empty;

        [Required][MaxLength(20)]public string Availability { get; set; } = string.Empty;
    }
}
