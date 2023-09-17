import { Component, OnInit } from '@angular/core';
import { IUser } from 'src/app/Interfaces/IUser';
import { ITicket } from 'src/app/Interfaces/iticket';
import { AuthCheckService } from 'src/app/Services/auth-check.service';
import { TicketViewService } from 'src/app/Services/ticket-view.service';

@Component({
  selector: 'app-history',
  templateUrl: './history.component.html',
  styleUrls: ['./history.component.sass'],
})
export class HistoryComponent implements OnInit {
  tickets!: ITicket[];
  history: ITicket[] = []; // Initialize history as an empty array
  currentUser!: IUser;
  isLoggedIn = false;

  constructor(
    private ticketService: TicketViewService,
    private authService: AuthCheckService
  ) {}

  ngOnInit(): void {
    this.authService.isLoggedIn().subscribe((status) => {
      this.isLoggedIn = status;
    });

    this.ticketService
      .getTickets(this.authService.currentUserSession().userId)
      .subscribe((tickets) => {
        this.tickets = tickets;

        // Get the current date
        const today = new Date();

        // Filter and update ticket statuses
        this.history = this.tickets.filter((ticket) => {
          if (ticket.status === 'CANCELLED') {
            return true; // Include cancelled tickets in history
          } else if (ticket.status === 'BOOKED') {
            const journeyDate = new Date(ticket.journeyDate);
            if (today > journeyDate) {
              ticket.status = 'JOURNEY DONE';
              return true; // Include updated 'BOOKED' tickets in history
            }
          }
          return false; // Exclude other 'BOOKED' tickets
        });
      });
  }
}
