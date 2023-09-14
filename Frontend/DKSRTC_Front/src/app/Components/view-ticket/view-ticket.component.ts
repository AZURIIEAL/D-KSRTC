import { Component } from '@angular/core';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { IBookingDetails } from '../../Interfaces/ibooking-details';
import { TicketCancellationService } from '../../Services/ticket-cancellation.service';
import { IBookedBus } from 'src/app/Interfaces/ibooked-bus';
import { Ipassenger } from 'src/app/Interfaces/ipassenger';
import { Subscription } from 'rxjs';
import { BookedBusService } from 'src/app/Services/booked-bus.service';
import { BookingService } from 'src/app/Services/booking.service';
import { IPayload } from 'src/app/Interfaces/ipayload';
import { IBookingPayload } from 'src/app/Interfaces/ibooking-payload';

@Component({
  selector: 'app-view-ticket',
  templateUrl: './view-ticket.component.html',
  styleUrls: ['./view-ticket.component.sass']
})
export class ViewTicketComponent {
  public bookedBus: Array<IPayload> = [];
  public newPassengerList: Array<Ipassenger> = [];
  subs?: Subscription;
  BookingId:number=0;
  total:number=0;

  i:number=this.bookedBus[0].booking.userId;

  constructor(private bookingService: BookingService) {}

    ngOnInit(){



    
      this.subs = this.bookingService.bookingDataSubject.subscribe(
        (x) => (this.bookedBus = x)
      );
      
     

     
    }


}
