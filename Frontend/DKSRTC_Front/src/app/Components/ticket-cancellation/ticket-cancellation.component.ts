import { Component } from '@angular/core';
import { TicketCancellationService } from '../../Services/ticket-cancellation.service';
import { ActivatedRoute, Router } from '@angular/router';
import { IBookingDetails } from '../../Interfaces/ibooking-details';

@Component({
  selector: 'app-ticket-cancellation',
  templateUrl: './ticket-cancellation.component.html',
  styleUrls: ['./ticket-cancellation.component.sass']
})
export class TicketCancellationComponent {
  bookingId:Number=0;
  
  constructor(private route:ActivatedRoute,private router:Router,private ticketCancellation: TicketCancellationService){}


  public bookingDetails: Array<IBookingDetails>=[]


  private fetchPassengerDetails(): void {
    this.ticketCancellation.getPassengerDetails().subscribe(
      (data: Array<IBookingDetails>) => {
        this.bookingDetails = data;
        console.log(this.bookingDetails)
      }
    );
  }
  cancelTickets(passengerId:Number) {
    this.ticketCancellation.cancelTicket(passengerId).subscribe((res: any)=>{
      alert('ticket cancelled'+res)
      this.fetchPassengerDetails();
    });
   }

  ngOnInit(){
    this.fetchPassengerDetails

    // const currentTime = new Date();

    
    

  }

  
   

}



