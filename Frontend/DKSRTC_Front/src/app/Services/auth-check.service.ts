import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { IUser } from '../Interfaces/IUser';

@Injectable({
  providedIn: 'root',
})
export class AuthCheckService {
  private loggedIn = new BehaviorSubject<boolean>(false);

  constructor(private http: HttpClient) {}
  url: string = 'https://localhost:44386/api/User';

  public LoggedUser: IUser = {
    userId: 0,
    firstName: '',
    lastName: '',
    email: '',
    password: '',
    phoneNumber: '',
    address: '',
  };

  public login(email: string, password: string) {
    let queryParams = new HttpParams();
    queryParams = queryParams
      .append('Email', email)
      .append('Password', password);
    return this.http
      .get<IUser>(`${this.url}/validate-user-login`, { params: queryParams })
      .pipe(
        tap({
          next: (x) => {
            if (x?.email === email) {
              this.loggedIn.next(true);
              this.LoggedUser = {
                userId: x.userId,
                firstName: x.firstName,
                lastName: x.lastName,
                email: x.email,
                password: x.password,
                phoneNumber: x.phoneNumber,
                address: x.address,
              };
              return this.LoggedUser;
            }
            return null;
          },
          error: () => {
            this.loggedIn.next(false);
            return null;
          },
        })
      );
  }
  logOut() {
    this.loggedIn.next(false);
  }
  currentUserSession(){
    return this.LoggedUser;
  }

  isLoggedIn(): Observable<boolean> {
    return this.loggedIn.asObservable();
  }
}
