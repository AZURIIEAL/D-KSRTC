using D_KSRTC.Models;
using D_KSRTC.Repositories.Payments;
using MediatR;

namespace D_KSRTC.Requests.Commands.Payments.UpdatePayment
{
    public class UpdatePaymentCommandHandler : IRequestHandler<UpdatePaymentCommand, int>
    {
        private readonly IPaymentRepository _paymentRepository;

        public UpdatePaymentCommandHandler(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<int> Handle(UpdatePaymentCommand command, CancellationToken cancellationToken)
        {
            var payment = new Payment
            {
                PaymentId = command.PaymentId,
                BookingId = command.BookingId,
                Amount = command.Amount,
                PaymentStatus = command.PaymentStatus
            };

            return await _paymentRepository.UpdatePaymentAsync(payment);
        }
    }
}
