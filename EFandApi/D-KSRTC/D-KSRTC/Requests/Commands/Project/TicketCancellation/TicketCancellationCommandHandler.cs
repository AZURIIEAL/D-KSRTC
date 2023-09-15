using Azure.Core;
using D_KSRTC.Data;
using D_KSRTC.Models;
using D_KSRTC.Requests.Commands.Seats.PatchSeatAvailability;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace D_KSRTC.Requests.Commands.Project.TicketCancellation
{
    public class TicketCancellationCommandHandler : IRequestHandler<TicketCancellationCommand, bool>
    {
        private readonly DKSRTCContext _dbContext;

        public TicketCancellationCommandHandler(DKSRTCContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Handle(TicketCancellationCommand command, CancellationToken cancellationToken)
        {
            var res = await _dbContext.Passenger.FindAsync(command.passengerId);
            if (res == null)
            {
                throw new FileNotFoundException();
            }
            res.Status = "CANCELLED";
            await _dbContext.SaveChangesAsync(cancellationToken);


            var seatInfo = await _dbContext.Seat.FindAsync(res.SeatId);
            var seatPatch = new PatchSeatAvailabilityCommand()
            {
                SeatID = res.SeatId,
                Availability = "AVAILABLE"
            };

            seatInfo!.UpdateSeatAvailabltity(seatPatch.Availability);
            if (seatPatch is not null)
            {
                try
                {

                    await _dbContext.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw;
                }
            }

            return true;
        }
    }
}




