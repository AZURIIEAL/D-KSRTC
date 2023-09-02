using D_KSRTC.Models;

namespace D_KSRTC.Repositories.Times
{
    public interface ITimeRepository
    {
        Task<Time> AddTimeAsync(Time time);
        Task<int> DeleteTimeAsync(int timeId);
        Task<List<Time>> GetAllTimesAsync();
        Task<Time?> GetTimeByIdAsync(int timeId);
        Task<int> UpdateTimeAsync(Time time);
    }
}
