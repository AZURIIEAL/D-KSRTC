using D_KSRTC.Data;
using D_KSRTC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;

namespace D_KSRTC.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly DKSRTCContext _dbContext;

        public UserRepository(DKSRTCContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> AddUserAsync(User user)
        {
            try
            {
                _dbContext.User.Add(user);
                await _dbContext.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<User?> DeleteUserAsync(int userId)
        {
            try
            {
                var user = await _dbContext.User.FindAsync(userId);
                if (user != null)
                {
                    _dbContext.User.Remove(user);
                    await _dbContext.SaveChangesAsync();
                }
                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            try
            {
                return await _dbContext.User.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<User?> GetUserByIdAsync(int userId)
        {
            try
            {
                return await _dbContext.User.FindAsync(userId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public bool HasEmail(string email)
        {
            try
            {
                return _dbContext.User.Any(x => x.Email == email);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

  

        public async Task<User> UpdateUserAsync(User user)
        {
            try
            {
                //This line of code sets the state of the locationDetails entity to Modified within the Entity Framework contex
                //This indicates that the entity has been modified and its changes need to be saved to the database.
                _dbContext.Entry(user).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<User?> ValidateLoginAsync(string email, string password)
        {
            var res = await _dbContext.User.FirstOrDefaultAsync(x => x.Email == email);
            if(res?.Password == password)
            {
                return res;
            }
            return null;
        }
    }
}
