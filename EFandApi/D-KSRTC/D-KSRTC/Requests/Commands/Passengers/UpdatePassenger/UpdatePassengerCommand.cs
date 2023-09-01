using MediatR;

namespace D_KSRTC.Requests.Commands.Passengers.UpdatePassenger
{
    public class UpdatePassengerCommand : IRequest<int>
    {
        public int PassengerId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Gender { get; set; } = string.Empty;
        public int SeatId { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public int BookingId { get; set; }

        public UpdatePassengerCommand(int passengerId,int bookingid, string firstName, string lastName, int age, string gender, int seatId, string phoneNumber, string email)
        {
            BookingId = bookingid;
            PassengerId = passengerId;
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
