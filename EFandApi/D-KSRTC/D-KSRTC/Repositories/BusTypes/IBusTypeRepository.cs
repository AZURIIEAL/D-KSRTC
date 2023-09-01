using D_KSRTC.Models;

namespace D_KSRTC.Repositories.BusTypes
{
    public interface IBusTypeRepository
    {
        Task<List<BusType>> GetAllBusTypesAsync();
        Task<BusType?> GetBusTypeByIdAsync(int typeId);
        Task<BusType> AddBusTypeAsync(BusType busType);
        Task<BusType> UpdateBusTypeAsync(BusType busType);
        Task<BusType?> DeleteBusTypeAsync(int typeId);
    }
}


