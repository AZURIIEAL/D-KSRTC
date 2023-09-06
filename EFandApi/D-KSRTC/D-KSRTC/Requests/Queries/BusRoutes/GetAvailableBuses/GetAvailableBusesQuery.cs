using D_KSRTC.DTO_s;
using MediatR;

namespace D_KSRTC.Requests.Queries.BusRoutes.GetAvailableBuses
{
    public class GetAvailableBusesQuery : IRequest<List<AvailableBuses>>
    {
        public int FromId { get; set; }
        public int ToId { get; set; }
        public DateTime Date { get; set; }

        public GetAvailableBusesQuery()
        {
                
        }
        public GetAvailableBusesQuery(int fromId , int toId, DateTime ondate)
        {
            FromId = fromId;
            ToId = toId;
            Date = ondate;      
        }
    }
}
