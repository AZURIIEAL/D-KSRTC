using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace D_KSRTC.Models
{
    public class Time
    {
        [Key]
        public int TimeId { get; set; }
        //Hemce no need of configuration files
        [Required]
        public DateTime BusTime { get; set; }

    }
}
