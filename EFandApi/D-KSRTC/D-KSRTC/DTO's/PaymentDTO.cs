namespace D_KSRTC.DTO_s
{
    public class PaymentDTO
    {
        public int BookingId { get; set; }
        public int Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentStatus { get; set; } = string.Empty;
    }
}
