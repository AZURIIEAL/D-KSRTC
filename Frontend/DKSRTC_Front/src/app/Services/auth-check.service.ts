import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthCheckService {
  private loggedIn = new BehaviorSubject<boolean>(false);

  constructor(private http: HttpClient) { }
  url: string = 'https://localhost:44386/api/LocationDetails';

  login() {
    this.loggedIn.next(true);
  }

  // Logout the user
  logout() {
    // Implement logout logic here
    // After logout, set loggedIn to false
    this.loggedIn.next(false);
  }

  // Observable to subscribe to login status
  isLoggedIn(): Observable<boolean> {
    return this.loggedIn.asObservable();
  }
}
