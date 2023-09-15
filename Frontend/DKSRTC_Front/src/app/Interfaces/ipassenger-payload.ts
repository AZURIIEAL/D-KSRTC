export interface IPassengerPayload {
    bookingId: number,
    firstName: string,
    lastName: string,
    age: number | null,
    gender: string,
    seatId: string | number | undefined,
    seatName:string;
    phoneNumber: string,
    email: string,
    status: string,
    fromLocation :string,
    toLocation:string
}
