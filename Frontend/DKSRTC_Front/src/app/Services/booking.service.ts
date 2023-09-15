import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ISeats } from '../Interfaces/iseats';
import { BehaviorSubject, Observable } from 'rxjs';
import { Ipassenger } from '../Interfaces/ipassenger';
import { IPayload } from '../Interfaces/ipayload';


@Injectable({
  providedIn: 'root'
})
export class BookingService {
  public bookings: any[] = [];
  public bookingDataSubject: BehaviorSubject<any> = new BehaviorSubject<any>({});
  public passengerDataSubject: BehaviorSubject<any[]> = new BehaviorSubject<any[]>([]);
  public bookingData: Observable<any[]> = this.bookingDataSubject.asObservable();
  passengerObjectsServiceObject: Ipassenger[] = [];

  constructor(private http: HttpClient) { }
  url: string = 'https://localhost:44386/api';
  public getSeatAvailability(BusId:number,onDate:Date) {
    
    let queryParams = new HttpParams();
    queryParams = queryParams.append("BusId",BusId)
    .append("Date",onDate.toLocaleTimeString());
    return this.http.get<ISeats[]>(`${this.url}/Seat`,{params:queryParams});
  }
  public addBooking(booking: any) {
    this.bookings.push(booking);
    this.bookingDataSubject.next(booking);
  }  
  public addPassengers(passenger:any){
    this.passengerObjectsServiceObject.push(passenger);
    this.passengerDataSubject.next(this.passengerObjectsServiceObject);
  }
  public createReservation(toAdd:IPayload){
    return this.http.post(`${this.url}/Project/booking-data`,toAdd)

  }


  
}
