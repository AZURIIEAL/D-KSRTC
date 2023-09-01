using D_KSRTC.Data;
using D_KSRTC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;

namespace D_KSRTC.Repositories.BusTypes
{
    public class BusTypeRepository : IBusTypeRepository
    {
        private readonly DKSRTCContext _dbContext;

        public BusTypeRepository(DKSRTCContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BusType> AddBusTypeAsync(BusType busType)
        {
            try
            {
                _dbContext.BusType.Add(busType);
                await _dbContext.SaveChangesAsync();
                return busType;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<BusType?> DeleteBusTypeAsync(int typeId)
        {
            try
            {
                var busType = await _dbContext.BusType.FindAsync(typeId);
                if (busType != null)
                {
                    _dbContext.BusType.Remove(busType);
                    await _dbContext.SaveChangesAsync();
                }
                return busType;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<List<BusType>> GetAllBusTypesAsync()
        {
            try
            {
                return await _dbContext.BusType.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<BusType?> GetBusTypeByIdAsync(int typeId)
        {
            try
            {
                return await _dbContext.BusType.FindAsync(typeId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<BusType> UpdateBusTypeAsync(BusType busType)
        {
            try
            {
                _dbContext.Entry(busType).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return busType;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}




