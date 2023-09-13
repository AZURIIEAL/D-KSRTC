export interface IBillingPayload {
  bookingId: number;
  userId: number;
  billingDate: Date;
  totalAmount: number;
  paymentMethod: string | null | undefined;
}
