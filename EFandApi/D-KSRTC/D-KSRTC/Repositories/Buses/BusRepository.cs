using D_KSRTC.Data;
using D_KSRTC.Models;
using Microsoft.EntityFrameworkCore;

namespace D_KSRTC.Repositories.Buses
{
    public class BusRepository : IBusRepository
    {
        private readonly DKSRTCContext _dbContext;

        public BusRepository(DKSRTCContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Bus> AddBusTypeCategoryAsync(Bus busDetails)
        {
            try
            {
                _dbContext.Bus.Add(busDetails);
                await _dbContext.SaveChangesAsync();
                return busDetails;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<Bus?> DeleteBusTypeCategoryAsync(int busId)
        {
            try
            {
                var bus = await _dbContext.Bus.FindAsync(busId);
                if (bus != null)
                {
                    _dbContext.Bus.Remove(bus);
                    await _dbContext.SaveChangesAsync();
                }
                return bus;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<List<Bus>> GetAllBusTypeCategoryAsync()
        {
            try
            {
                return await _dbContext.Bus.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<Bus?> GetBusTypeCategoryByIdAsync(int busId)
        {
            try
            {
                return await _dbContext.Bus.FindAsync(busId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<Bus> UpdateBusTypeCategoryAsync(Bus busDetails)
        {
            try
            {
                _dbContext.Entry(busDetails).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return busDetails;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}