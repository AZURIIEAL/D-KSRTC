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

<<<<<<< HEAD:EFandApi/D-KSRTC/D-KSRTC/Repositories/BusType/BusTypeRepository.cs
        public async Task<Models.BusType?> DeleteBusTypeAsync(int typeId)
        {
            try
            {
                var bus = await _dbContext.BusType.FindAsync(typeId);
                if (bus != null)
                {
                    _dbContext.BusType.Remove(bus);
                    await _dbContext.SaveChangesAsync();
                }
                return bus;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            };
        }

        public async Task<List<Models.BusType>> GetAllBusTypeAsync()
=======
        public Task<List<BusType>> GetAllBusTypeAsync()
>>>>>>> 8c675610c88b5442183a887c2c15a74ff614209e:EFandApi/D-KSRTC/D-KSRTC/Repositories/BusTypes/BusTypeRepository.cs
        {
            try
            {
              var  getBusTypeById = await _dbContext.BusType.ToListAsync();
                return getBusTypeById;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

<<<<<<< HEAD:EFandApi/D-KSRTC/D-KSRTC/Repositories/BusType/BusTypeRepository.cs
     
=======
        public Task<BusType> GetBusTypeByIdAsync(int typeId)
        {
            throw new NotImplementedException();
        }
>>>>>>> 8c675610c88b5442183a887c2c15a74ff614209e:EFandApi/D-KSRTC/D-KSRTC/Repositories/BusTypes/BusTypeRepository.cs

        public Task<BusType> UpdateBusTypeAsync(BusType typeName)
        {
            throw new NotImplementedException();
        }

    }
}
