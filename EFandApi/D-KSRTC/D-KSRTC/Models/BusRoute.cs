using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace D_KSRTC.Models
{
    public class BusRoute
    {
        [Key]public int BusRouteId { get; set; }
        //Hemce no need of configuration files
        public int BusId { get; set; }
        [ForeignKey("BusId")]
        [DeleteBehavior(DeleteBehavior.Restrict)]

        public Bus? BusIdNavigation { get; set; }

         public int RouteId { get; set; }
        [ForeignKey("RouteId")]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Route? RouteIdNavigation { get; set; }


        public int TimeId { get; set; }
        [ForeignKey("TimeId")]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Time? TimeIdNavigation { get; set; }


        public DateTime RouteDate { get; set; }
    }
}
