import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { IUser } from 'src/app/Interfaces/IUser';
import { IBillingPayload } from 'src/app/Interfaces/ibilling-payload';
import { IBookingPayload } from 'src/app/Interfaces/ibooking-payload';
import { Ipassenger } from 'src/app/Interfaces/ipassenger';
import { IPassengerPayload } from 'src/app/Interfaces/ipassenger-payload';
import { IPayload } from 'src/app/Interfaces/ipayload';
import { IPaymentPayload } from 'src/app/Interfaces/ipayment-payload';
import { AuthCheckService } from 'src/app/Services/auth-check.service';
import { BookingService } from 'src/app/Services/booking.service';
import { TicketViewService } from 'src/app/Services/ticket-view.service';

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
  passengerPayload:IPassengerPayload[] = [];
  payload!:IPayload;

  paymentMethod: string | null | undefined = '';
  constructor(
    private authService: AuthCheckService,
    private bookingService: BookingService,
    private router: Router,
    private ticketService: BookingService
  ) {}

  PaymentFormGroup = new FormGroup({
    paymentBy: new FormControl('', [Validators.required]),
  });
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
      this.paymentMethod = this.PaymentFormGroup.value.paymentBy;
      const toSendBooking: IBookingPayload = {
        userId: +this.currentUser.userId,
        busRouteId: this.booking['busRoute'],
        bookingDate: this.booking['bookingDate'],
        journeyDate: this.booking['journeyDate'],
        totalAmount: (+this.booking['amount']),
        status: 'BOOKED',
      };
      this.passengers.forEach((element) => {
        const toSendPassenger: IPassengerPayload = {
          bookingId: 0,
          firstName: element.firstName,
          lastName: element.lastName,
          age: element.age,
          gender: element.gender,
          seatId: element.seatId,
          seatName:element.seatName,
          phoneNumber: element.phoneNumber,
          email: element.email,
          status: 'BOOKED',
          fromLocation:this.ticketService.traversalData.fromName,
          toLocation:this.ticketService.traversalData.toName
        };
        this.passengerPayload.push(toSendPassenger);

      });
      const toSendBiling: IBillingPayload = {
        bookingId: 0,
        userId: this.currentUser.userId,
        billingDate: this.booking['bookingDate'],
        totalAmount: (+this.booking['amount']),
        paymentMethod: this.paymentMethod,
      };
      const toSendPayment: IPaymentPayload = {
        bookingId:0,
        amount:(+this.booking['amount']),
        paymentDate:this.booking['bookingDate'],
        paymentStatus:"PAID"
      };
      


      this.payload={
        booking: toSendBooking,
        passengers:this.passengerPayload ,
        billing:toSendBiling,
        payment:toSendPayment,
      }

      console.log(this.payload)
      this.bookingService.createReservation(this.payload).subscribe((data)=>
      console.log(data))
      this.router.navigate(['/upcoming-journeys']);
      
    } else {
      alert('Login to continue');
    }
  }
}
