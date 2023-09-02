using D_KSRTC.Models;
using D_KSRTC.Repositories.Payments;
using MediatR;

namespace D_KSRTC.Requests.Commands.Payments.AddPayment
{
    public class AddPaymentCommandHandler : IRequestHandler<AddPaymentCommand, Payment>
    {
        private readonly IPaymentRepository _paymentRepository;

        public AddPaymentCommandHandler(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<Payment> Handle(AddPaymentCommand command, CancellationToken cancellationToken)
        {
            var payment = new Payment
            {
                BookingId = command.BookingId,
                Amount = command.Amount,
                PaymentDate = command.PaymentDate,
                PaymentStatus = command.PaymentStatus
            };

            return await _paymentRepository.AddPaymentAsync(payment);
        }
    }
}
