using D_KSRTC.Models;

namespace D_KSRTC.Repositories.Bookings
{
    public interface IBookingRepository
    {
        Task<List<Booking>> GetAllBookingsAsync();
        Task<Booking?> GetBookingByIdAsync(int bookingId);
        Task<Booking> AddBookingAsync(Booking booking);
        Task<Booking> UpdateBookingAsync(Booking booking);
        Task<Booking?> DeleteBookingAsync(int bookingId);
    }
}
