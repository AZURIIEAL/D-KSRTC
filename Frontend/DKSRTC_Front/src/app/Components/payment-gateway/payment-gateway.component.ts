import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IUser } from 'src/app/Interfaces/IUser';
import { Ipassenger } from 'src/app/Interfaces/ipassenger';
import { AuthCheckService } from 'src/app/Services/auth-check.service';
import { BookingService } from 'src/app/Services/booking.service';

@Component({
  selector: 'app-payment-gateway',
  templateUrl: './payment-gateway.component.html',
  styleUrls: ['./payment-gateway.component.sass'],
})
export class PaymentGatewayComponent implements OnInit {
  isLoggedIn: boolean = false;
  booking: any = {};
  passengers: Ipassenger[] = [];
  currentUser!: IUser;

  paymentMethod: string = '';
  constructor(
    private authService: AuthCheckService,
    private bookingService: BookingService,
    private router: Router
  ) {}

  ngOnInit() {
    this.authService.isLoggedIn().subscribe((status) => {
      this.isLoggedIn = status;
      this.currentUser = this.authService.currentUserSession();
    });
    this.bookingService.bookingDataSubject.subscribe((x: any) => {
      this.booking = x;
    });
    this.bookingService.passengerDataSubject.subscribe((x: Ipassenger[]) => {
      this.passengers = x;
    });
  }
  submitPayment() {
    if (this.isLoggedIn) {
      const inputValue = (<HTMLInputElement>document.getElementById('payment')).value;

      const toSend: any = {
        userId: (+this.currentUser.userId),
        busRouteId: this.booking['busRoute'],
        bookingDate:this.booking['bookingDate'].toLocaleDateString(),
        journeyDate: this.booking['journeyDate'].toLocaleDateString(),
        totalAmount: (+this.booking["amount"]),
        status: 'BOOKED',
      };
    } else {
      alert('Login to continue');
    }
  }
}
