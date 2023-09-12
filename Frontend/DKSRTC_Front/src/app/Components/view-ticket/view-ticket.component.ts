import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-view-ticket',
  templateUrl: './view-ticket.component.html',
  styleUrls: ['./view-ticket.component.sass']
})
export class ViewTicketComponent {
  constructor(private route:ActivatedRoute,private router:Router){}


  change() {
    this.router.navigate(['View-Ticket']);
  }

}
