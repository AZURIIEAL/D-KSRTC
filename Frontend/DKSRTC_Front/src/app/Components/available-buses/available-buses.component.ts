import { Component, OnInit } from '@angular/core';
import { BusRouteService } from '../../Services/bus-route.service';
import { IBus } from 'src/app/Interfaces/IBus';
import { Observable, forkJoin, map } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthCheckService } from 'src/app/Services/auth-check.service';

@Component({
  selector: 'app-available-buses',
  templateUrl: './available-buses.component.html',
  styleUrls: ['./available-buses.component.sass'],
})
export class AvailableBusesComponent implements OnInit {
  constructor(
    private authService: AuthCheckService,
    private busRouteService: BusRouteService,
    private activatedRoute: ActivatedRoute
  ) {}

  showFilters = false;
  get filterButtonText() {
    return this.showFilters ? 'Hide Filters' : 'Show Filters';
  }

  availableBuses!: Observable<IBus[]>;
  availableFilters: string[][] = [];
  fromLocationId!: number;
  isLoggedIn = false;
  fromLocationName!: string;
  toLocationId!: number;
  toLocationName!: string;
  onDate!: Date;
  selectedSpeederCommute: string = '';
  selectedAccommodationClass: string = '';
  keys = [
    'Bus Name',
    'Departure Time',
    'Distance',
    'Speeder Commute',
    'Accommodation Class',
    'Seats Available',
    'Fare',
    'For Booking',
  ];

  noBusesFound = false;

  alertLogin() {
    alert('Please login to view tickets or book tickets for your next journey');
  }

  applyFilters() {
    this.filteredBuses = this.availableBuses.pipe(
      map((buses: IBus[]) => buses.filter((bus) => this.filterBus(bus)))
    );

    this.filteredBuses.subscribe((buses) => {
      this.noBusesFound = buses.length === 0;
    });
  }

  filteredBuses: Observable<IBus[]> | undefined;

  toggleFilters() {
    this.showFilters = !this.showFilters;
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

      this.availableBuses = this.busRouteService.getFilteredBuses(
        this.fromLocationId,
        this.toLocationId,
        this.onDate
      );

      const FiltercategoriesDropdown$ = this.busRouteService.getAllFilters()[0];
      const FiltertypesDropdown$ = this.busRouteService.getAllFilters()[1];

      forkJoin([FiltercategoriesDropdown$, FiltertypesDropdown$]).subscribe(
        (results: string[][]) => {
          this.availableFilters = results;
        }
      );

      this.filteredBuses = this.availableBuses.pipe(
        map((buses: IBus[]) => buses.filter((bus) => this.filterBus(bus)))
      );

      this.filteredBuses.subscribe((buses) => {
        this.noBusesFound = buses.length === 0;
      });

      this.authService.isLoggedIn().subscribe((status) => {
        this.isLoggedIn = status;
      });
    });
  }

  filterBus(bus: IBus): boolean {
    if (!this.selectedSpeederCommute && !this.selectedAccommodationClass) {
      return true;
    }

    if (
      this.selectedSpeederCommute &&
      bus.categoryName !== this.selectedSpeederCommute
    ) {
      return false;
    }

    if (
      this.selectedAccommodationClass &&
      bus.typeName !== this.selectedAccommodationClass
    ) {
      return false;
    }

    return true;
  }
}
