export interface IBookingPayload {
  userId: number;
  busRouteId: number;
  bookingDate: Date;
  journeyDate: Date;
  totalAmount: number;
  status: string;
}
