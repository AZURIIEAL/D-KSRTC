import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IBus } from '../Interfaces/IBus';

@Injectable({
  providedIn: 'root'
})
export class BusRouteService {

  constructor(private http: HttpClient) { }
  url: string = 'https://localhost:44386/api/BusRoute';
  public getFilteredBuses() {
    return this.http.get<IBus[]>(`${this.url}/available-bus-routes`);
  }
}
