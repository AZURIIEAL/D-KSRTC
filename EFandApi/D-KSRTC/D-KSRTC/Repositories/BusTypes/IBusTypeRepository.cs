using D_KSRTC.Models;

namespace D_KSRTC.Repositories.BusTypes
{
    public interface IBusTypeRepository
    {
        public Task<List<BusType> >GetAllBusTypeAsync();
        public Task<BusType?> GetBusTypeByIdAsync(int typeId); 
        public Task<BusType> AddBusTypeAsync(BusType typeName);
        public Task<BusType> UpdateBusTypeAsync(BusType typeName);
        //Add delete bus type.
        public Task<BusType> DeleteBusTypeAsync(int TypeId);
    }
}


