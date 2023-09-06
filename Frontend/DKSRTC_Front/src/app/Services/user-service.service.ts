import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ILogin } from '../Interfaces/ilogin';

@Injectable({
  providedIn: 'root'
})
export class UserServiceService {
  

  

  constructor(private http: HttpClient) { }
  url: string = 'https://localhost:44386/api/User';
   getLoginDetails() {
    return this.http.get<ILogin[]>(`${this.url}/get-all`);
  }
}
