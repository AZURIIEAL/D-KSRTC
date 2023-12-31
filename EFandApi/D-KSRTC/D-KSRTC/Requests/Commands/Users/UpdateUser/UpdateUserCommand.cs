﻿using D_KSRTC.Models;
using MediatR;

namespace D_KSRTC.Requests.Commands.Users.UpdateUser
{
    public class UpdateUserCommand :IRequest<int>
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public UpdateUserCommand(int id,string firstname, string lastname, string email, string password, string phonenumber, string address)
        {
            Id = id;
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            Password = password;
            PhoneNumber = phonenumber;
            Address = address;
        }
    }
}
