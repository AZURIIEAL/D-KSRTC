import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Observable } from 'rxjs';
import { map, startWith } from 'rxjs/operators';
import { ISearch } from 'src/app/Interfaces/Isearch';
import { ILocationDetails } from 'src/app/Interfaces/ILocationDetails';
import { dataLocationDetailsService } from 'src/app/Services/data-LocationDetails.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.sass']
})
export class HomeComponent implements OnInit {
  constructor(private router: Router, private service: dataLocationDetailsService) {}

  busSearchForm = new FormGroup({
    fromLocation: new FormControl(''),
    toLocation: new FormControl(''),
    travelDate: new FormControl(''),
  });

  filteredOptions: Observable<string[]> | undefined;

  options: string[] = []; // Initialize as an empty array of strings

  searchCriteria: ISearch = {
    FromLocation: '',
    ToLocation: '',
    JourneyDate: new Date(),
  };

  ngOnInit(): void {
    // Fetch location details and map them to location names
    this.service.getLocationDetails().subscribe((locationDetails: ILocationDetails[]) => {
      this.options = locationDetails.map((location: ILocationDetails) => location.locationName);
      this.filteredOptions = this.busSearchForm.get('fromLocation')!.valueChanges.pipe(
        startWith(''),
        map(value => this._filter(value || '')),
      );
    });
  }

  private _filter(value: string): string[] {
    const filterValue = value.toLowerCase();
    return this.options.filter(option => option.toLowerCase().includes(filterValue));
  }
  searchBus() {
    const fromLocationControl = this.busSearchForm.get('fromLocation');
    const toLocationControl = this.busSearchForm.get('toLocation');
    const travelDateControl = this.busSearchForm.get('travelDate');

    if (fromLocationControl && toLocationControl && travelDateControl) {
      this.searchCriteria.FromLocation = fromLocationControl.value || '';
      this.searchCriteria.ToLocation = toLocationControl.value || '';
      this.searchCriteria.JourneyDate = travelDateControl.value || new Date();

      console.log('Searching for buses...');
      console.log('From:', this.searchCriteria.FromLocation);
      console.log('To:', this.searchCriteria.ToLocation);
      console.log('Date:', this.searchCriteria.JourneyDate);
      
      // Optionally, you can navigate to a new page using the router
      // this.router.navigate(['/search-results']); // Replace with your route
    }
  }
}
