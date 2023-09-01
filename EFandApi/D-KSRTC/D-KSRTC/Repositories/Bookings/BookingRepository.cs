using D_KSRTC.Data;
using D_KSRTC.Models;
using Microsoft.EntityFrameworkCore;

namespace D_KSRTC.Repositories.Bookings
{
    public class BookingRepository : IBookingRepository
    {
        private readonly DKSRTCContext _dbContext;

        public BookingRepository(DKSRTCContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Booking> AddBookingAsync(Booking booking)
        {
            try
            {
                _dbContext.Booking.Add(booking);
                await _dbContext.SaveChangesAsync();
                return booking;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<Booking?> DeleteBookingAsync(int bookingId)
        {
            try
            {
                var booking = await _dbContext.Booking.FindAsync(bookingId);
                if (booking != null)
                {
                    _dbContext.Booking.Remove(booking);
                    await _dbContext.SaveChangesAsync();
                }
                return booking;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<List<Booking>> GetAllBookingsAsync()
        {
            try
            {
                return await _dbContext.Booking.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<Booking?> GetBookingByIdAsync(int bookingId)
        {
            try
            {
                return await _dbContext.Booking.FindAsync(bookingId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<Booking> UpdateBookingAsync(Booking booking)
        {
            try
            {
                _dbContext.Entry(booking).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return booking;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}

