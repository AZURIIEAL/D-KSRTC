using D_KSRTC.Models;
using D_KSRTC.Repositories.Users;
using D_KSRTC.Requests.Queries.Users.GetUserById;
using MediatR;

namespace D_KSRTC.Requests.Queries.Users.ValidateUserLogin
{
    public class ValidateUserLoginQueryHandler : IRequestHandler<ValidateUserLoginQuery, User>
    {
        private readonly IUserRepository _userRepository;
        public ValidateUserLoginQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(ValidateUserLoginQuery request, CancellationToken cancellationToken)
        {
            User? toOut = await _userRepository.ValidateLoginAsync(request.Email,request.Password);
            if (toOut == null)
            {
                throw new Exception(nameof(toOut));
            }
            return toOut;
        }
    }
}
