using D_KSRTC.Data;
using D_KSRTC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;

namespace D_KSRTC.Repositories.BusTypes
{
    public class BusTypeRepository : IBusTypeRepository
    {
        public readonly DKSRTCContext _dbContext;
        private readonly object _dbcontext;

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

        public async Task<BusType> DeleteBusTypeAsync(int TypeId)
        {
            try
            {
               var TypeId = await _dbContext.BusType.FindAsync(TypeId);
                if (TypeId != null)
                {
                    _dbContext.LocationDetails.Remove (TypeId);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
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

        //    public async Task<BusType> DeleteBusTypeAsync(int TypeId)
        //    {
        //        try
        //        {
        //            var busType = await _dbContext.BusType.FindAsync(TypeId);
        //            if (busType != null)
        //            {
        //                _dbContext.BusType.Remove(busType);
        //                await _dbContext.SaveChangesAsync();
        //            }
        //            return busType;
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex);
        //            throw;
        //        }
        //    }

        //    public Task<List<BusType>> GetAllBusTypeAsync()
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public Task<BusType> GetBusTypeByIdAsync(int typeId)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public Task<BusType> UpdateBusTypeAsync(BusType typeName)
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        //public async Task<List<BusType>> GetAllBusTypeAsync()
        //{
        //    try
        //    {
        //        var busType = await _dbContext.BusType.FindAsync(TypeId);
        //        if (busType != null)
        //        {
        //            _dbContext.LocationDetails.Remove(busType);
        //            await _dbContext.SaveChangesAsync();
        //        }
        //        return busType;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex);
        //        throw;
        //    }
    }
          

      
    }
