using D_KSRTC.Models;

namespace D_KSRTC.Repositories.Passengers
{
    public interface IPassengerRepository
    {
        Task<List<Passenger>> GetAllPassengersAsync();
        Task<Passenger?> GetPassengerByIdAsync(int passengerId);
        Task<Passenger> AddPassengerAsync(Passenger passenger);
        Task<Passenger> UpdatePassengerAsync(Passenger passenger);
        Task<Passenger?> DeletePassengerAsync(int passengerId);
    }
}
