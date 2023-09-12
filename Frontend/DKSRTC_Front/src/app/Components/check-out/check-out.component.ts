import { Component, OnInit } from '@angular/core';
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
  booking:any[]=[];
  passengers: Ipassenger[] = [];
  constructor( private authService: AuthCheckService,private bookingService: BookingService) {

  }
  ngOnInit(){
    this.authService.isLoggedIn().subscribe((status) => {
      this.isLoggedIn = status;
    })
    this.bookingService.bookingDataSubject.subscribe((x: any[]) => {
      this.booking=x;
    })
    this.bookingService.passengerDataSubject.subscribe((x: Ipassenger[]) => {
      this.passengers = x;
    })


  }

}
