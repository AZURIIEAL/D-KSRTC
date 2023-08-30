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

        public async Task<BusType> AddBusTypeAsync(BusType typeName)
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

        public Task<List<BusType>> GetAllBusTypeAsync()
        {
            throw new NotImplementedException();
        }

        public Task<BusType> GetBusTypeByIdAsync(int typeId)
        {
            throw new NotImplementedException();
        }

        public Task<BusType> UpdateBusTypeAsync(BusType typeName)
        {
            throw new NotImplementedException();
        }

    }
}
