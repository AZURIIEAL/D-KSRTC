import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { ISearch } from 'src/app/Interfaces/Isearch';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.sass']
})
export class HomeComponent {
  constructor(private router: Router) {}

  busSearchForm = new FormGroup({
    fromLocation: new FormControl(''),
    toLocation: new FormControl(''),
    travelDate: new FormControl(''),
  });

  searchCriteria: ISearch = {
    FromLocation: '',
    ToLocation: '',
    JourneyDate: new Date(),
  };

  searchBus() {
    // Access form control values from busSearchForm FormGroup
    const fromLocationControl = this.busSearchForm.get('fromLocation');
    const toLocationControl = this.busSearchForm.get('toLocation');
    const travelDateControl = this.busSearchForm.get('travelDate');

    // Check if form controls have values and are not null or undefined
    if (fromLocationControl && toLocationControl && travelDateControl) {
      this.searchCriteria.FromLocation = fromLocationControl.value || ''; // Handle null or undefined
      this.searchCriteria.ToLocation = toLocationControl.value || ''; // Handle null or undefined
      this.searchCriteria.JourneyDate = travelDateControl.value || new Date(); // Handle null or undefined

      console.log('Searching for buses...');
      console.log('From:', this.searchCriteria.FromLocation);
      console.log('To:', this.searchCriteria.ToLocation);
      console.log('Date:', this.searchCriteria.JourneyDate);
      
    }
  }
}
