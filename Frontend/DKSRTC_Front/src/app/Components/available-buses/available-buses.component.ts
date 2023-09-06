import { Component, OnInit } from '@angular/core';
import { BusRouteService } from '../../Services/bus-route.service';
import { IBus } from 'src/app/Interfaces/IBus';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-available-buses',
  templateUrl: './available-buses.component.html',
  styleUrls: ['./available-buses.component.sass']
})
export class AvailableBusesComponent implements OnInit {
  constructor(private busRouteService:BusRouteService) {}
  availableBuses:Observable<IBus[]> | undefined = undefined;
  keys = ["Bus Name","Departure Time", "Distance","Speeder Commute","Accomodation Class","Seats Available","Fare"];
  ngOnInit(): void {
    this.availableBuses = this.busRouteService.getFilteredBuses();
  }

}
