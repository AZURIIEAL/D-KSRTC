using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace D_KSRTC.DTO_s
{
    public class AvailableBuses
    {
        public int BusId { get; set; }
        public string BusName { get; set; } = string.Empty;
        public DateTime Time { get; set; }
        public float Distance { get; set; }
        public int BusRouteCurrent { get; set; } 
        public int SeatAvailability { get; set; } = 0;
        public DateTime Duration { get; set; }
        public int Sequence { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string TypeName { get; set; } =string.Empty;
        public float perDistanceFare { get; set; }
        public float BaseFare { get; set; }


    }
}
