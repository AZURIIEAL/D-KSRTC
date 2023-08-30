using D_KSRTC.Data;
using D_KSRTC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;

namespace D_KSRTC.Repositories.BusType
{
    public class BusTypeRepository : IBusTypeRepository
    {
        private readonly DKSRTCContext _dbContext;
        public BusTypeRepository(DKSRTCContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Models.BusType> AddBusTypeAsync(Models.BusType typeName)
        {
            try
            {
                _dbContext.BusType.Add(typeName);
                await _dbContext.SaveChangesAsync();
                return typeName;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public Task<Models.BusType?> DeleteBusTypeAsync(int typeId)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            };
        }

        public Task<List<Models.BusType>> GetAllBusTypeAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Models.BusType> GetBusTypeByIdAsync(int typeId)
        {
            throw new NotImplementedException();
        }

        public Task<Models.BusType> UpdateBusTypeAsync(Models.BusType typeName)
        {
            throw new NotImplementedException();
        }

    }
}
