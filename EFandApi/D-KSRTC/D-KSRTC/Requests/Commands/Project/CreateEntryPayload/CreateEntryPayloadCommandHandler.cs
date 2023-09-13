using Azure.Core;
using D_KSRTC.Models;
using D_KSRTC.Repositories.Billings;
using D_KSRTC.Repositories.Bookings;
using D_KSRTC.Repositories.Passengers;
using D_KSRTC.Repositories.Payments;
using D_KSRTC.Repositories.Seats;
using MediatR;


namespace D_KSRTC.Requests.Commands.Project.CreateEntryPayload
{
    public class CreateEntryPayloadCommandHandler : IRequestHandler<CreateEntryPayloadCommand, bool>
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IPassengerRepository _passengerRepository;
        private readonly IBillingRepository _billingRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly ISeatRepository _seatRepository;


        public CreateEntryPayloadCommandHandler(IBookingRepository bookingRepository,
            IPassengerRepository passengerRepository, IBillingRepository billingRepository, 
            IPaymentRepository paymentRepository, ISeatRepository seatRepository)
        {
            _bookingRepository = bookingRepository;
            _passengerRepository = passengerRepository;
            _billingRepository = billingRepository;
            _paymentRepository = paymentRepository;
            _seatRepository = seatRepository;
        }
        public async Task<bool> Handle(CreateEntryPayloadCommand command, CancellationToken cancellationToken)
        {
            var booking = new Booking()
            {
                UserId = command.payload.Booking.UserId,
                BusRouteId = command.payload.Booking.BusRouteId,
                BookingDate = command.payload.Booking.BookingDate,
                JourneyDate = command.payload.Booking.JourneyDate,
                TotalAmount = command.payload.Booking.TotalAmount,
                Status = command.payload.Booking.Status,
               

            };
            var resultBooking = await _bookingRepository.AddBookingAsync(booking);

            foreach (var passengerItem in command.payload.Passengers)
            {
                if (passengerItem != null)
                {
                    var passMan = new Passenger()
                    {
                        BookingId = resultBooking.BookingId,
                        FirstName = passengerItem.FirstName,
                        LastName = passengerItem.LastName,
                        Age = passengerItem.Age,
                        Gender = passengerItem.Gender,
                        SeatId = passengerItem.SeatId,
                        PhoneNumber = passengerItem.PhoneNumber,
                        Email = passengerItem.Email,
                        Status = passengerItem.Status,
                    };
                    var resultPassenger = await _passengerRepository.AddPassengerAsync(passMan);
                    var res = await _seatRepository.GetSeatByIdAsync(passengerItem.SeatId);

                    res.UpdateSeatAvailabltity(passMan.Status);
                    var resultSeat =  await _seatRepository.UpdateSeatAsync(res);


                }
            }
            Billing billing = new Billing
            {
                BookingId = resultBooking.BookingId,
                UserId = command.payload.Billing.UserId,
                BillingDate = command.payload.Billing.BillingDate ,
                TotalAmount = command.payload.Billing.TotalAmount,
                PaymentMethod = command.payload.Billing.PaymentMethod,
            };
            var resultBilling =  await _billingRepository.AddBillingAsync(billing);


            var payment = new Payment()
            {
                BookingId = resultBooking.BookingId,
                Amount = command.payload.Payment.Amount,
                PaymentDate = command.payload.Payment.PaymentDate,
                PaymentStatus = command.payload.Payment.PaymentStatus,
            };

            var resultPayment=  await _paymentRepository.AddPaymentAsync(payment);





            return true;

        }
    }
}
