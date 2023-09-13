using Azure.Core;
using D_KSRTC.Models;

namespace D_KSRTC.Repositories.Seats
{
    public interface ISeatRepository
    {
        Task<Seat> AddSeatAsync(Seat seat);
        Task<int> DeleteSeatAsync(int seatId);
        Task<List<Seat>> GetAllSeatsAsync();
        Task<Seat?> GetSeatByIdAsync(int seatId);
        Task<int> UpdateSeatAsync(Seat seat);
        Task<List<Seat?>> GetSeatAvailability(int BusId, DateTime Date);
    }
}
