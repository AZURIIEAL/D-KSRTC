import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IBus } from '../Interfaces/IBus';

@Injectable({
  providedIn: 'root'
})
export class BusRouteService {

  constructor(private http: HttpClient) { }
  url: string = 'https://localhost:44386/api';
  public getFilteredBuses(from:number,to:number,onDate:Date) {
    
    let queryParams = new HttpParams();
    queryParams = queryParams.append("FromId",from)
    .append("ToId",to)
    .append("Date",onDate.toLocaleDateString());
    return this.http.get<IBus[]>(`${this.url}/BusRoute/available-bus-routes`,{params:queryParams});
  }

  //For getting all the buses from the database,and then filtering them based on the parameters
  public getAllFilters() {
    const categories = this.http.get<string[]>(`${this.url}/BusCategory`);
    const types = this.http.get<string[]>(`${this.url}/BusType`);
    const tosend = [categories, types];
    return tosend;

  }
}
