using D_KSRTC.Data;
using D_KSRTC.Models;
using Microsoft.EntityFrameworkCore;

namespace D_KSRTC.Repositories.Times
{
    public class TimeRepository : ITimeRepository
    {
        private readonly DKSRTCContext _dbContext;

        public TimeRepository(DKSRTCContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Time> AddTimeAsync(Time time)
        {
            try
            {
                _dbContext.Time.Add(time);
                await _dbContext.SaveChangesAsync();
                return time;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<int> DeleteTimeAsync(int timeId)
        {
            try
            {
                var time = await _dbContext.Time.FindAsync(timeId);
                if (time != null)
                {
                    _dbContext.Time.Remove(time);
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

        public async Task<List<Time>> GetAllTimesAsync()
        {
            try
            {
                return await _dbContext.Time.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<Time?> GetTimeByIdAsync(int timeId)
        {
            try
            {
                return await _dbContext.Time.FindAsync(timeId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<int> UpdateTimeAsync(Time time)
        {
            try
            {
                _dbContext.Entry(time).State = EntityState.Modified;
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