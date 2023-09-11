import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ISeats } from '../Interfaces/iseats';
import { BehaviorSubject, Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class BookingService {
  private bookings: any[] = []; // Replace 'any[]' with your specific booking data type
  private bookingDataSubject: BehaviorSubject<any[]> = new BehaviorSubject<any[]>([]);
  public bookingData: Observable<any[]> = this.bookingDataSubject.asObservable();

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
    this.bookingDataSubject.next(this.bookings);
  }
  public createReservation(toAdd:any){
    return this.http.post(`${this.url}`,toAdd)

  }
}
