using D_KSRTC.Data;
using D_KSRTC.DTO_s;
using D_KSRTC.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace D_KSRTC.Requests.Queries.Project.Ticket
{
    public class TicketQueryHandler : IRequestHandler<TicketQuery, List<TicketDTO>>
    {
        private readonly DKSRTCContext _dbContext;

        public TicketQueryHandler(DKSRTCContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<TicketDTO>> Handle(TicketQuery request, CancellationToken cancellationToken)
        {
            DateTime currentTime = DateTime.Now;

            var data = await _dbContext.Booking
               .Include(x => x.PassengerNav)
               .ThenInclude(x => x.Seat)
               .Include(x => x.BusRoute)
               .ThenInclude(x => x!.Route)
               .Include(x => x.BusRoute)
               .ThenInclude(x => x!.BusIdNavigation)
               .Where(x => x.UserId == request.UserId && x.JourneyDate > currentTime)
               .ToListAsync(cancellationToken: cancellationToken);

            var ticketList = new List<TicketDTO>();


            foreach (var item in data)
            {

                foreach (var passenger in item.PassengerNav)
                {
                    var ticket = new TicketDTO
                    {
                        FirstName = passenger.FirstName,
                        LastName = passenger.LastName,
                        BusRouteName = item.BusRoute!.Route!.RouteName,
                        JourneyDate = item.JourneyDate,
                        PassengerId = passenger.PassengerId,
                        BusTime = item.BusRoute.Time,
                        BusName = item.BusRoute.BusIdNavigation!.BusName,
                        Seat = passenger.Seat!.SeatNumber,
                        Status = passenger.Status, 
                    };

                    ticketList.Add(ticket);
                }
            }

            return ticketList;
        }
    }


}
