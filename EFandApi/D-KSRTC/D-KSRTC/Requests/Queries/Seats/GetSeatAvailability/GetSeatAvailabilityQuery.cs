using D_KSRTC.Models;
using MediatR;

namespace D_KSRTC.Requests.Queries.Seats.GetSeatAvailability
{
    public class GetSeatAvailabilityQuery :IRequest<List<Seat>>
    {
        public int BusId { get; set; }
        public DateTime Date { get; set;}

        public GetSeatAvailabilityQuery()
        {
            
        }
        public GetSeatAvailabilityQuery(int busId,DateTime date )
        {
            BusId = busId;
            Date = date;           
        }
 

    }
}
