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

        public object?[]? TypeId { get; private set; }

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
               var bus = await _dbContext.BusType.FindAsync(TypeId);
                if (bus != null)
                {
                    _dbContext.BusType.Remove (bus);
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

        public async Task<List<BusType>> GetAllBusTypeAsync()
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

        public async Task<BusType> UpdateBusTypeAsync(BusType typeName)
        {
            try
            {
                _dbContext.Entry(_dbContext.BusType).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return typeName;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

         }

      

       
    }
          

      
    
