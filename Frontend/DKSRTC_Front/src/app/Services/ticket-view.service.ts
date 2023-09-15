import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { ITicket } from '../Interfaces/iticket';
import { HttpClient, HttpParams } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TicketViewService {

  url: string = 'https://localhost:44386/api';
  constructor(private http: HttpClient) { }
  public getTickets(UserId:number) { 
    let queryParams = new HttpParams();
    queryParams = queryParams.append("userId",UserId);
    return this.http.get<ITicket[]>(`${this.url}/Project/get-tickets`,{params:queryParams});
  }
  public TicketCancel(passengerId:number) { 
    let queryParams = new HttpParams();
    queryParams = queryParams.append("passengerId",passengerId);
    return this.http.patch<boolean>(`${this.url}/Project/ticket-cancellation`,{params:queryParams});
  }
}
