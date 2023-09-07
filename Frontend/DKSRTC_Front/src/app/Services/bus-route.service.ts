import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IBus } from '../Interfaces/IBus';

@Injectable({
  providedIn: 'root'
})
export class BusRouteService {

  constructor(private http: HttpClient) { }
  url: string = 'https://localhost:44386/api/BusRoute';
  public getFilteredBuses(from:number,to:number,onDate:Date) {
    
    let queryParams = new HttpParams();
    queryParams = queryParams.append("FromId",from)
    .append("ToId",to)
    .append("Date",onDate.toLocaleTimeString());
    return this.http.get<IBus[]>(`${this.url}/available-bus-routes`,{params:queryParams});
  }
}
