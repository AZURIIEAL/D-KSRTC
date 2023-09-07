using D_KSRTC.Models;

namespace D_KSRTC.Repositories.Users
{
    public interface IUserRepository
    {
        public Task<List<User>> GetAllUsersAsync();
        public Task<User?> GetUserByIdAsync(int UserId);
        public Task<User> AddUserAsync(User user);
        public Task<User> UpdateUserAsync(User userId);
        public Task<User?> DeleteUserAsync(int userId);
        public bool HasEmail(string email);

    }
}
