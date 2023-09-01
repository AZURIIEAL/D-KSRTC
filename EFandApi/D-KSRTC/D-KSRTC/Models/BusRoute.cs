using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace D_KSRTC.Models
{
    public class BusRoute
    {
        [Key]public int BusRouteId { get; set; }
        //Hemce no need of configuration files
        public int BusId { get; set; }
        [ForeignKey("BusId")]public Bus? BusIdNavigation { get; set; }

         public int RouteId { get; set; }

        [ForeignKey("RouteId")]public Route? RouteIdNavigation { get; set; }

        public int TimeId { get; set; }

        [ForeignKey("RouteId")] public Time? TimeIdNavigation { get; set; }
    }
}
