import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class LoginServiceService {

  

  isAdminLoggedIn = false;
  isCustomerLoggedIn = false;
  constructor(private http: HttpClient) { }

  isAdminLogin() {
    if (this.isAdminLoggedIn) {
      return true;
    } else {
      return false;
    }
  }
  
    isCustomerLogin() {
      if (this.isCustomerLoggedIn) {
        return true;
      } else {
        return false;
      }
    }
}
