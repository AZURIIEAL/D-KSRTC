// import { Component } from '@angular/core';
// import { ActivatedRoute, ParamMap, Router } from '@angular/router';
// import { IBookingDetails } from '../../Interfaces/ibooking-details';
// import { TicketCancellationService } from '../../Services/ticket-cancellation.service';
// import { IBookedBus } from 'src/app/Interfaces/ibooked-bus';
// import { Ipassenger } from 'src/app/Interfaces/ipassenger';
// import { Subscription } from 'rxjs';
// import { BookedBusService } from 'src/app/Services/booked-bus.service';
// import { BookingService } from 'src/app/Services/booking.service';

// @Component({
//   selector: 'app-view-ticket',
//   templateUrl: './view-ticket.component.html',
//   styleUrls: ['./view-ticket.component.sass']
// })
// export class ViewTicketComponent {
//   public bookedBus: Array<IBookedBus> = [];
//   public newPassengerList: Array<Ipassenger> = [];
//   subs?: Subscription;
//   BookingId:number=0;
//   total:number=0;

//   constructor(private bookedBusService: BookedBusService,
//     private passengerService:PassengerDetailsService,
//     private router: Router,
//     private bookingService: BookingService) {}

//     ngOnInit(){
//       this.subs = this.bookedBusService.select.subscribe(
//         (x: Array<IBookedBus>) => (this.bookedBus = x)
//       );

//       this.subs=this.passengerService.passenger.subscribe(
//         (x:Array<Ipassenger>)=>{
//           (this.newPassengerList=x)
//         this.BookingId=this.newPassengerList[0].
//       }
//       )
//     }

// // viewTicket(formdata:any){
// //   const BookingId=formdata.BookingId;
// //   this.ticketService.cancelTicket(BookingId).subscribe((data)=>{
// //     this.ticket=data;
// //     this.show=true
// //   });

// // }

// //   change() {
// //     this.router.navigate(['View-Ticket']);
// //   }

// }
