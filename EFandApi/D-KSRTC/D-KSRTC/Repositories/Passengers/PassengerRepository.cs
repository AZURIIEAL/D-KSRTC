using D_KSRTC.Data;
using D_KSRTC.Models;
using Microsoft.EntityFrameworkCore;

namespace D_KSRTC.Repositories.Passengers
{
    public class PassengerRepository : IPassengerRepository
    {
        private readonly DKSRTCContext _dbContext;

        public PassengerRepository(DKSRTCContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Passenger> AddPassengerAsync(Passenger passenger)
        {
            try
            {
                _dbContext.Passenger.Add(passenger);
                await _dbContext.SaveChangesAsync();
                return passenger;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<Passenger?> DeletePassengerAsync(int passengerId)
        {
            try
            {
                var passenger = await _dbContext.Passenger.FindAsync(passengerId);
                if (passenger != null)
                {
                    _dbContext.Passenger.Remove(passenger);
                    await _dbContext.SaveChangesAsync();
                }
                return passenger;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<List<Passenger>> GetAllPassengersAsync()
        {
            try
            {
                return await _dbContext.Passenger.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<Passenger?> GetPassengerByIdAsync(int passengerId)
        {
            try
            {
                return await _dbContext.Passenger.FindAsync(passengerId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<Passenger> UpdatePassengerAsync(Passenger passenger)
        {
            try
            {
                _dbContext.Entry(passenger).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return passenger;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
