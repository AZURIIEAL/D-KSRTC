using D_KSRTC.Repositories.Users;

using MediatR;


namespace D_KSRTC.Requests.Commands.Users.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, int>
    {

        private readonly IUserRepository _userRepository;
        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;        
        }

        public async Task<int> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            var userDetails = await _userRepository.GetUserByIdAsync(command.Id);
            if (userDetails == null) { return default; }

            userDetails.FirstName = command.FirstName;
            userDetails.LastName = command.LastName;
            userDetails.Email = command.Email;
            userDetails.PhoneNumber = command.PhoneNumber;
            userDetails.Address = command.Address;
            userDetails.Password = command.Password;
            await _userRepository.UpdateUserAsync(userDetails);
            return 1;
        }
    }
}
