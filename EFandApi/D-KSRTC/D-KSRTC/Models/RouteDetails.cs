using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace D_KSRTC.Models
{
    public class RouteDetails
    {

        [Key]
        public int RDId { get; set; } //RouteDetailsID
        //Hemce no need of configuration files

        public int RouteId { get; set; } 

        [ForeignKey("RouteId")]
        public Route? RouteIdNavigation { get; set; }

        public int StopId { get; set; } 

        [ForeignKey("StopId")]
        public LocationDetails? StopIdNavigation { get; set; }

        public int Sequence { get; set; } 
        public float Distance { get; set; }
        public DateTime Duration { get; set; }
    }
}
