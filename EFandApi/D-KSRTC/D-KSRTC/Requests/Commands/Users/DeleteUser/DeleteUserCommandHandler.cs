using D_KSRTC.Repositories.Users;
using MediatR;
using System.ComponentModel.Design;

namespace D_KSRTC.Requests.Commands.Users.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, int>
    {
        private readonly IUserRepository _userRepository;
        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            var locationDetails = await _userRepository.DeleteUserAsync(command.Id);
            if (locationDetails == null)
            { return default; }
            return 1;
        }
    }
}
