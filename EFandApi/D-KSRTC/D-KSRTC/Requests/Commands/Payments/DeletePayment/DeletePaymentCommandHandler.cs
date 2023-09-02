using D_KSRTC.Repositories.Payments;
using MediatR;

namespace D_KSRTC.Requests.Commands.Payments.DeletePayment
{
    public class DeletePaymentCommandHandler : IRequestHandler<DeletePaymentCommand, int>
    {
        private readonly IPaymentRepository _paymentRepository;

        public DeletePaymentCommandHandler(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<int> Handle(DeletePaymentCommand command, CancellationToken cancellationToken)
        {
            return await _paymentRepository.DeletePaymentAsync(command.PaymentId);
        }
    }
}
