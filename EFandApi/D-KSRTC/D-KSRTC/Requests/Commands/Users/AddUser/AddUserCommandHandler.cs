using D_KSRTC.Models;
using D_KSRTC.Repositories.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

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
            var emailpattern = @"^[a-zA-Z0-9.!#$%&'+-/=?^_`{|}~]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)$";
            var passPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";

            string verifiedMail;
            string verifiedPassword;

            var regexE = new Regex(emailpattern);
            var regexP = new Regex(passPattern);
            if (regexE.IsMatch(command.Email)) {
                verifiedMail = command.Email; }
            else
                throw new Exception("EmailId Invalid");
            if (regexP.IsMatch(command.Password))
            {
                verifiedPassword = command.Password;
            }
            else
                throw new Exception("Password not strong");
            bool isEmailExist = _userRepository.HasEmail(command.Email);
            if (isEmailExist) { 
                throw new Exception("Email already exists"); }
            var userNew = new User()
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = verifiedMail,
                PhoneNumber = command.PhoneNumber,
                Password = verifiedPassword,
                Address = command.Address
            };

            return await _userRepository.AddUserAsync(userNew);
        }
    }
}
