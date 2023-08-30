using D_KSRTC.Models;

namespace D_KSRTC.Repositories.BusType
{
    public interface IBusTypeRepository
    {
        public Task<List<Models.BusType>> GetAllBusTypeAsync();
        public Task<Models.BusType> GetBusTypeByIdAsync(int typeId); //String or int in ID
        public Task<Models.BusType> AddBusTypeAsync(Models.BusType typeName);
        public Task<Models.BusType> UpdateBusTypeAsync(Models.BusType typeName);
        public Task<Models.BusType?> DeleteBusTypeAsync(int typeId); //String or int in ID
      
    }
}
