using D_KSRTC.Models;

namespace D_KSRTC.DTO_s
{
    public class PayloadDTO
    {
        public BookingDTO? Booking { get; set; }
        public List<PassengerDTO>? Passengers { get; set; }
        public BillingDTO? Billing { get; set; }
        public PaymentDTO? Payment { get; set; }
    }

    public class ss
    {
        public int PassengerId { get; set; }
    }
}
