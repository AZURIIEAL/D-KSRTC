import { Component, OnInit } from '@angular/core';
import { BusRouteService } from '../../Services/bus-route.service';
import { IBus } from 'src/app/Interfaces/IBus';
import { Observable, map } from 'rxjs';
import { dataLocationDetailsService } from '../../Services/data-LocationDetails.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-available-buses',
  templateUrl: './available-buses.component.html',
  styleUrls: ['./available-buses.component.sass'],
})
export class AvailableBusesComponent implements OnInit {
  constructor(
    private busRouteService: BusRouteService,
    private locationDataService: dataLocationDetailsService,
    private activatedRoute: ActivatedRoute
  ) {}

  availableBuses!: Observable<IBus[]>;
  fromLocationId!: number;
  fromLocationName!: string;
  toLocationId!: number;
  toLocationName!: string;
  onDate!: Date;
  keys = [
    'Bus Name',
    'Departure Time',
    'Distance',
    'Speeder Commute',
    'Accomodation Class',
    'Seats Available',
    'Fare',
  ];

  ngOnInit(): void {
    this.activatedRoute.queryParamMap.subscribe((x) => {
      const fromLocationParam = x.get('fromLocation');
      if (fromLocationParam) {
        this.fromLocationName = fromLocationParam;
      }

      const toLocationParam = x.get('toLocation');
      if (toLocationParam) {
        this.toLocationName = toLocationParam;
      }

      const journeyDateParam = x.get('journeyDate');
      if (journeyDateParam) {
        this.onDate = new Date(journeyDateParam);
      }
    });

    this.availableBuses = this.busRouteService.getFilteredBuses(1 ,1003,this.onDate);  
    console.log(this.availableBuses)
  }

}
