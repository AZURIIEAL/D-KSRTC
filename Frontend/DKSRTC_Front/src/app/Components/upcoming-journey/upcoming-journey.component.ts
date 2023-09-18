import { Component, OnInit } from '@angular/core';
import { ITicket } from 'src/app/Interfaces/iticket';
import { TicketViewService } from 'src/app/Services/ticket-view.service';
import { AuthCheckService } from 'src/app/Services/auth-check.service';
import { IUser } from 'src/app/Interfaces/IUser';
import { Router } from '@angular/router';

@Component({
  selector: 'app-upcoming-journey',
  templateUrl: './upcoming-journey.component.html',
  styleUrls: ['./upcoming-journey.component.sass'],
})
export class UpcomingJourneyComponent implements OnInit {
  tickets!: ITicket[];
  currentUser!: IUser;
  isLoggedIn = false;
  constructor(
    private ticketService: TicketViewService,
    private authService: AuthCheckService,
    private router: Router
  ) {}
  ngOnInit(): void {
    this.authService.isLoggedIn().subscribe((status) => {
      this.isLoggedIn = status;
    });

    this.ticketService
      .getTickets(this.authService.currentUserSession().userId)
      .subscribe((tickets) => {
        // Filter out the tickets with status "BOOKED"
        this.tickets = tickets.filter((ticket) => ticket.status === 'BOOKED');
        console.log(this.tickets);
      });
  }
  cancelTicket(passengerId: number) {
    if (this.isLoggedIn) {
      const text = 'Do you want to cancel this ticket?';
      if (confirm(text) == true) {
        this.ticketService.TicketCancel(passengerId).subscribe((x) => {
          if (x) {
            console.log('Cancelled');

            // Find the index of the passenger in the Tickets array
            const passengerIndex = this.tickets.findIndex(
              (ticket) => ticket.passengerId === passengerId
            );

            // Remove the passenger from the Tickets array
            if (passengerIndex !== -1) {
              this.tickets.splice(passengerIndex, 1);
            }
          } else {
            console.log('An error occurred while cancellation.');
          }
        });
        this.router.navigate(['/upcoming-journeys']);
      } else {
        // User canceled the confirmation
      }
    }
  }
}
