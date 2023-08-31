using D_KSRTC.Models;
using D_KSRTC.Repositories.Users;
using MediatR;

namespace D_KSRTC.Requests.Queries.Users.GetUserById
{
    public class GetUsersByIdQueryHandler : IRequestHandler<GetUsersByIdQuery, User>
    {
        private readonly IUserRepository _userRepository;
        public GetUsersByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;        
        }
        public async Task<User> Handle(GetUsersByIdQuery request, CancellationToken cancellationToken)
        {
            User? toOut = await _userRepository.GetUserByIdAsync(request.Id);
            return toOut ?? new User();
        }
    }
}
