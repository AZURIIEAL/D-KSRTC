import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ISearch } from 'src/app/Interfaces/Isearch';
import { ILocationDetails } from 'src/app/Interfaces/ILocationDetails';
import { dataLocationDetailsService } from 'src/app/Services/data-LocationDetails.service';
import { AuthCheckService } from 'src/app/Services/auth-check.service';
import { BookingService } from 'src/app/Services/booking.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.sass'],
})
export class HomeComponent implements OnInit {
  isLoggedIn = false;
  options: ILocationDetails[] = [];
  filteredFromLocations: ILocationDetails[] = [];
  filteredToLocations: ILocationDetails[] = [];
  ToLocation!: string;
  FromLocation!: string;
  journeyDate!: string | Date;

  constructor(
    private router: Router,
    private service: dataLocationDetailsService,
    private authService: AuthCheckService,
    private ticketService :BookingService
  ) {}

  busSearchForm = new FormGroup({
    fromLocation: new FormControl('', [Validators.required]),
    toLocation: new FormControl('' , [Validators.required]),
    travelDate: new FormControl('', [Validators.required]),
  });

  searchCriteria: ISearch = {
    FromLocation: '',
    ToLocation: '',
    JourneyDate: new Date(),
  };

  ngOnInit() {
    this.authService.isLoggedIn().subscribe((status) => {
      this.isLoggedIn = status;
    });
    this.getLocationData();
  }

  getLocationData() {
    this.service.getLocationDetails().subscribe((data: ILocationDetails[]) => {
      this.options = data;
    });
  }

  filterLocations(controlName: string, event: any) {
    const inputValue = event.target.value; //to note
    const targetLocations =
      controlName === 'fromLocation'
        ? this.filteredFromLocations
        : this.filteredToLocations;
    targetLocations.length = 0; // Clear the array

    if (inputValue.trim() === '') {
      // If input is empty, show all options
      targetLocations.push(...this.options);
    } else {
      // Filter the options based on the input value
      targetLocations.push(
        ...this.options.filter((option) =>
          option.locationName.toLowerCase().includes(inputValue.toLowerCase())
        )
      );
    }
  }

  searchBus() {
    const fromLocationControl = this.busSearchForm.get('fromLocation');
    const toLocationControl = this.busSearchForm.get('toLocation');
    const travelDateControl = this.busSearchForm.get('travelDate');

    if (
      fromLocationControl?.valid &&
      toLocationControl?.valid &&
      travelDateControl?.valid
    ) {
      this.searchCriteria.FromLocation = fromLocationControl.value || '';
      this.searchCriteria.ToLocation = toLocationControl.value || '';
      this.searchCriteria.JourneyDate = travelDateControl.value || new Date();
      this.ToLocation = this.searchCriteria.ToLocation;
      this.FromLocation = this.searchCriteria.FromLocation;
      this.journeyDate = this.searchCriteria.JourneyDate;
      const toLocationDetails = this.options.find(
        (location) => location.locationName === this.ToLocation
      );
      const fromLocationDetails = this.options.find(
        (location) => location.locationName === this.FromLocation
      );
      this.ticketService.addTraversalData(this.FromLocation,this.ToLocation)
      

      this.router.navigate(['/available-buses'], {
        queryParams: {
          fromLocation: this.FromLocation,
          fromLocationId: fromLocationDetails?.locationId,
          toLocation: this.ToLocation,
          toLocationId: toLocationDetails?.locationId,
          journeyDate: this.journeyDate,
        },
      });
    } else {
      alert('Please enter valid details');
    }
  }
}
