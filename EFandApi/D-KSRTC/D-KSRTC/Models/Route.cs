using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace D_KSRTC.Models
{
    public class Route
    {
        [Key]
        public int RouteId { get; set; }
        //Hemce no need of configuration files
        [Required]
        [MaxLength(100)]
        public string RouteName { get; set; } = string.Empty;

        public int SLId { get; set; } //Start locationId

        [ForeignKey("SLId")]
        [DeleteBehavior(DeleteBehavior.Restrict)]

        public LocationDetails? SLIdNavigation { get; set; }

        public int? ELId { get; set; } //End LocationId

        [ForeignKey("ELId")]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public LocationDetails? ELIdNavigation { get; set; }

        public virtual List<RouteDetails> RouteDetails { get; set; } = new();

        public float Distance { get; set; }
        public DateTime Duration { get; set; }
    }
}
