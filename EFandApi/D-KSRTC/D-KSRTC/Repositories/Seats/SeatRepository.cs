using D_KSRTC.Data;
using D_KSRTC.Models;
using Microsoft.EntityFrameworkCore;

namespace D_KSRTC.Repositories.Seats
{
    public class SeatRepository : ISeatRepository
    {
        private readonly DKSRTCContext _dbContext;

        public SeatRepository(DKSRTCContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Seat> AddSeatAsync(Seat seat)
        {
            try
            {
                _dbContext.Seat.Add(seat);
                await _dbContext.SaveChangesAsync();
                return seat;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<int> DeleteSeatAsync(int seatId)
        {
            try
            {
                var seat = await _dbContext.Seat.FindAsync(seatId);
                if (seat != null)
                {
                    _dbContext.Seat.Remove(seat);
                    await _dbContext.SaveChangesAsync();
                    return 1;
                }
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<List<Seat>> GetAllSeatsAsync()
        {
            try
            {
                return await _dbContext.Seat.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<Seat?> GetSeatByIdAsync(int seatId)
        {
            try
            {
                return await _dbContext.Seat.FindAsync(seatId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<int> UpdateSeatAsync(Seat seat)
        {
            try
            {
                _dbContext.Entry(seat).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
