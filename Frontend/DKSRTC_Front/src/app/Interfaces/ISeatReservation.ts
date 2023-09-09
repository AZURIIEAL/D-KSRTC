export interface ISeatReservation {
  FirstName: string;
  LastName: string;
  Age: number | null;
  Gender: string;
  SeatId: number | null |string; // You may want to use the actual SeatId here if it's available
  PhoneNumber: string;
  Email: string;
}

