import { Component, OnInit } from '@angular/core';
import { BusRouteService } from '../../Services/bus-route.service';
import { IBus } from 'src/app/Interfaces/IBus';
import { Observable } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthCheckService } from 'src/app/Services/auth-check.service';

@Component({
  selector: 'app-available-buses',
  templateUrl: './available-buses.component.html',
  styleUrls: ['./available-buses.component.sass'],
})
export class AvailableBusesComponent implements OnInit {
  constructor(
    private router: Router, 
    private authService: AuthCheckService,
    private busRouteService: BusRouteService,
    private activatedRoute: ActivatedRoute
  ) {}

  availableBuses!: Observable<IBus[]>;
  fromLocationId!: number;
  isLoggedIn = false;
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
    'For Booking'];

    AlertLogin(){
      alert("Please login to view tickets or book tickets for your next journey");
    }
  ngOnInit() {
    this.activatedRoute.queryParamMap.subscribe((x) => {
      const fromLocationParam = x.get('fromLocation');
      if (fromLocationParam) {
        this.fromLocationName = fromLocationParam;
      }
      const fromLocationIdParam = x.get('fromLocationId');
      if (fromLocationIdParam) {
        this.fromLocationId = parseInt(fromLocationIdParam, 10);
      }
      const toLocationParam = x.get('toLocation');
      if (toLocationParam) {
        this.toLocationName = toLocationParam;
      }
      const toLocationIdParam = x.get('toLocationId');
      if (toLocationIdParam) {
        this.toLocationId = parseInt(toLocationIdParam, 10);
      }
      const journeyDateParam = x.get('journeyDate');
      if (journeyDateParam) {
        this.onDate = new Date(journeyDateParam);
      }
    });
    this.availableBuses = this.busRouteService.getFilteredBuses(this.fromLocationId ,this.toLocationId,this.onDate);  
    console.log(this.availableBuses);
    this.authService.isLoggedIn().subscribe((status) => {
      this.isLoggedIn = status;
    })
  }}

