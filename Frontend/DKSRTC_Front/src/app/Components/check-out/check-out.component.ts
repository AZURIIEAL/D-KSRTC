import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IUser } from 'src/app/Interfaces/IUser';
import { Ipassenger } from 'src/app/Interfaces/ipassenger';
import { AuthCheckService } from 'src/app/Services/auth-check.service';
import { BookingService } from 'src/app/Services/booking.service';

@Component({
  selector: 'app-check-out',
  templateUrl: './check-out.component.html',
  styleUrls: ['./check-out.component.sass']
})
export class CheckOutComponent implements OnInit {
  isLoggedIn = false;
  booking:any={};
  passengers: Ipassenger[] = [];
  currentUser!:IUser;
  constructor( private authService: AuthCheckService,private bookingService: BookingService,private router: Router) {

  }
  ngOnInit(){
    this.authService.isLoggedIn().subscribe((status) => {
      this.isLoggedIn = status;
      // if(this.isLoggedIn){
        
      // }
      this.currentUser = this.authService.currentUserSession()
    })
    this.bookingService.bookingDataSubject.subscribe((x: any) => {
      this.booking=x;
    })
    this.bookingService.passengerDataSubject.subscribe((x: Ipassenger[]) => {
      this.passengers = x;
    })
  }
  ProceedToPayment(){
    this.router.navigate(['/payment-gateway'])

  }

}
