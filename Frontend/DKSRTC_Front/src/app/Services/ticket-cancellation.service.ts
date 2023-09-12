import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IBookingDetails } from '../Interfaces/ibooking-details';

@Injectable({
  providedIn: 'root'
})
export class TicketCancellationService {

  constructor(private http: HttpClient) { }
 readonly url: string = 'https://localhost:44386/api/Passenger';

//  cancelTicket(BookingId:Number):Observable<any>
//  {
//   return this.http.post(`${this.url}/Cancel-Ticket`,{BookingId})
//  }

cancelTicket(passengerId:Number) {
  return this.http.delete<IBookingDetails>
  (`${this.url}/${passengerId}`);
}

 getPassengerDetails(){
  return this.http.get<Array<IBookingDetails>>
  (`${this.url}`)
}

findById(id:number){
  return this.http.get<IBookingDetails>
  (`${this.url}/GetById?id=${id}`)
}
}
