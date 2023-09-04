import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ILocationDetails } from '../Interfaces/ILocationDetails';

@Injectable({
  providedIn: 'root'
})
export class dataLocationDetailsService {

  constructor(private http: HttpClient) { }
  url: string = 'https://localhost:44386/api/LocationDetails';
  public getLocationDetails() {
    return this.http.get<ILocationDetails[]>(`${this.url}/get-all`);
  }
}
