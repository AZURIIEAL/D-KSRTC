using D_KSRTC.Models;
using MediatR;

namespace D_KSRTC.Requests.Queries.Users.ValidateUserLogin
{
    public class ValidateUserLoginQuery :IRequest<User>
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public ValidateUserLoginQuery()
        {
        }
        public ValidateUserLoginQuery(string email,string password)
        {
            Email = email;
            Password = password;    
        }
    }
}
