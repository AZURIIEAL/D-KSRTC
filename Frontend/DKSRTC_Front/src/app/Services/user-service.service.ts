import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ILogin } from '../Interfaces/Ilogin';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserServiceService {
  
  constructor(private http: HttpClient) { }
  url: string = 'https://localhost:44386/api/User';
   getLoginDetails() {
    return this.http.get<ILogin[]>(`${this.url}/get-all`);
  }

  public addUser(user:ILogin):Observable<ILogin>
  {
    return this.http.post<ILogin>(this.url+"AddUser",user);
  }
}
