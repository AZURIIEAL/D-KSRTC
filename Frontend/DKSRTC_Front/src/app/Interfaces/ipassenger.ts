export interface Ipassenger {
    bookingId:number,
    firstName: string;
    lastName: string;
    age: number | null;
    gender: string;
    seatName:string;
    seatId: number |string | undefined; 
    phoneNumber: string;
    email: string;
}
