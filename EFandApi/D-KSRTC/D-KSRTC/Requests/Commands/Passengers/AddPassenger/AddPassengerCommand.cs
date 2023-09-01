using D_KSRTC.Models;
using MediatR;

namespace D_KSRTC.Requests.Commands.Passengers.AddPassenger
{
    public class AddPassengerCommand : IRequest<Passenger>
    {
        public int BookingId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public int SeatId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public AddPassengerCommand(int bookingId, string firstName, string lastName, int age, string gender, int seatId, string phoneNumber, string email)
        {
            BookingId = bookingId;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Gender = gender;
            SeatId = seatId;
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }
}
