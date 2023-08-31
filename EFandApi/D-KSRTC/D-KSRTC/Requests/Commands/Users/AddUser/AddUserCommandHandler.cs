using D_KSRTC.Models;
using D_KSRTC.Repositories.Users;
using MediatR;

namespace D_KSRTC.Requests.Commands.Users.AddUser
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, User>
    {
        private readonly IUserRepository _userRepository;
        public AddUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;   
        }
        public async Task<User> Handle(AddUserCommand command, CancellationToken cancellationToken)
        {
            var userNew = new User()
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
                PhoneNumber = command.PhoneNumber,
                Password = command.Password,
                Address = command.Address
            };

            return await _userRepository.AddUserAsync(userNew);
        }
    }
}
