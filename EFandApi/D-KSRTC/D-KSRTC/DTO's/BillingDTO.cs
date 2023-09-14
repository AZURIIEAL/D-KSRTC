namespace D_KSRTC.DTO_s
{
    public class BillingDTO
    {
        public int BookingId { get; set; }
        public int UserId { get; set; }
        public DateTime BillingDate { get; set; }
        public int TotalAmount { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
    }
}
