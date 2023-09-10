import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ILogin } from '../Interfaces/Ilogin';

@Injectable({
  providedIn: 'root'
})
export class UserAddService {

  constructor(private http: HttpClient) { }
  url: string = 'https://localhost:44386/api/User';
  public AddNewUser(UserObj:ILogin){
    return this.http.post(this.url,UserObj)
  }

}
