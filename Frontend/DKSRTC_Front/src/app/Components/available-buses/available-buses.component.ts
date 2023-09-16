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
  // Constructor function to inject services
  constructor(
    private authService: AuthCheckService, // AuthenticationService
    private busRouteService: BusRouteService, // Service for fetching bus routes
    private activatedRoute: ActivatedRoute // ActivatedRoute for route parameters
  ) {}

// Add this property to your component
showFilters = false;

// Function to toggle the filters
toggleFilters() {
  this.showFilters = !this.showFilters;
}

//Note this part -about getter function
// Add this getter function to change the button text based on the filter state
get filterButtonText() {
  return this.showFilters ? 'Hide Filters' : 'Show Filters';
}

  // Declare class properties
  availableBuses!: Observable<IBus[]>; // Observable to store the list of available buses
  availableFilters: string[][] = []; // Initialize the availableFilters property
  fromLocationId!: number; // Stores the ID of the departure location
  isLoggedIn = false; // Stores the login status
  fromLocationName!: string; // Stores the name of the departure location
  toLocationId!: number; // Stores the ID of the destination location
  toLocationName!: string; // Stores the name of the destination location
  onDate!: Date; // Stores the date of the journey
  selectedSpeederCommute: string = ''; // Initialize selectedSpeederCommute for filtering
  selectedAccommodationClass: string = ''; // Initialize selectedAccommodationClass for filtering
  keys = [
    'Bus Name',
    'Departure Time',
    'Distance',
    'Speeder Commute',
    'Accommodation Class',
    'Seats Available',
    'Fare',
    'For Booking',
  ]; // Array of keys for table headers

  // Function to display a login alert
  AlertLogin() {
    alert('Please login to view tickets or book tickets for your next journey');
  }

  // ngOnInit() is called when the component is initialized
  ngOnInit() {
    this.activatedRoute.queryParamMap.subscribe((x) => {
      // Extract and set route query parameters
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

      // Get available buses based on route parameters
      this.availableBuses = this.busRouteService.getFilteredBuses(
        this.fromLocationId,
        this.toLocationId,
        this.onDate
      );

      // Call the getAllFilters method from the service
      const FiltercategoriesDropdown$ = this.busRouteService.getAllFilters()[0]; // Get the first observable(categories)
      const FiltertypesDropdown$ = this.busRouteService.getAllFilters()[1]; // Get the second observable(types)

      // Subscribe to both observables and merge their results
      forkJoin([FiltercategoriesDropdown$, FiltertypesDropdown$]).subscribe(
        (results: string[][]) => {
          this.availableFilters = results; // Assign the result to availableFilters
          console.log(this.availableFilters); // Log the availableFilters here
        }
      );

      // Filter the buses based on selected criteria using RxJS pipe and map
      this.availableBuses = this.availableBuses.pipe(
        map((buses: IBus[]) => buses.filter((bus) => this.filterBus(bus)))
      );

      // Check if the user is logged in
      this.authService.isLoggedIn().subscribe((status) => {
        this.isLoggedIn = status;
      });
    });
  }

  // Function to filter buses based on selected criteria
  filterBus(bus: IBus): boolean {
    // Check if both filters are empty (no filtering)
    if (!this.selectedSpeederCommute && !this.selectedAccommodationClass) {
      return true;
    }

    // Check Speeder Commute filter
    if (
      this.selectedSpeederCommute &&
      bus.categoryName !== this.selectedSpeederCommute
    ) {
      return false;
    }

    // Check Accommodation Class filter
    if (
      this.selectedAccommodationClass &&
      bus.typeName !== this.selectedAccommodationClass
    ) {
      return false;
    }

    // If all checks pass, include the bus in the filtered list
    return true;
  }
}
